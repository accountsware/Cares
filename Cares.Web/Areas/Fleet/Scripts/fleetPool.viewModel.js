﻿/*
    Module with the view model for the FleetPool
*/
define("Fleet/fleetPool.viewModel",
    ["jquery", "amplify", "ko", "Fleet/fleetPool.dataservice", "Fleet/fleetPool.model", "common/confirmation.viewModel", "common/pagination"],
    function($, amplify, ko, dataservice, model, confirmation, pagination) {

        var ist = window.ist || {};
        ist.fleetPool = {
            viewModel: (function() {
                // the view 
                var view,

                    // Active FleetPool
                    selectedFleetPool = ko.observable(),
                    // fleetPools
                    fleetPools = ko.observableArray([]),
                    // Regions
                    regionsList = ko.observableArray([]),
                    //Country Base Region List
                    contryBaseRegionList = ko.observableArray([]),
                    // Operations
                    operationsList = ko.observableArray([]),
                    //counytr list
                    countryList = ko.observableArray([]),
                    // FleetPool Code
                    fleetPoolSeachFilter = ko.observable(),
                    //Operation Filter
                    fleetPoolOperationFilter = ko.observable(),
                    // region Filter
                    fleetPoolRegionFilter = ko.observable(),
                    // #region Busy Indicators
                    isLoadingFleetPools = ko.observable(false),
                    //Is Edit visible
                    isFleetPoolEditorVisible = ko.observable(false),
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Pagination
                    pager = ko.observable(),

                    // Get Fleet Pool Base Data
                    getFleetPoolBaseData = function(callBack) {
                        dataservice.getFleetPoolBasedata(null, {
                            success: function(data) {
                                operationsList.removeAll();
                                ko.utils.arrayPushAll(operationsList(), data.Operations);
                                operationsList.valueHasMutated();
                                regionsList.removeAll();
                                ko.utils.arrayPushAll(regionsList(), data.Regions);
                                regionsList.valueHasMutated();

                                contryBaseRegionList.removeAll();
                                ko.utils.arrayPushAll(contryBaseRegionList(), data.Regions);
                                contryBaseRegionList.valueHasMutated();

                                countryList.removeAll();
                                ko.utils.arrayPushAll(countryList(), data.Countries);
                                countryList.valueHasMutated();

                                if (callBack && callBack === 'function') {
                                    callBack()();
                                };
                            },
                            error: function(exceptionMessage, exceptionType) {
                                if (exceptionType === ist.exceptionType.CaresGeneralException) {
                                    toastr.error(exceptionMessage);
                                } else {
                                    toastr.error("Failed to load base data.");
                                }
                            }
                        });
                    },
                    //country selected form dd
                    countrySelected = function() {
                        //getRegions(newCountryFilter());
                    },
                    cancelSave = function() {
                        isFleetPoolEditorVisible(false);
                    },
                    //Validation Check function while saving Fleet Pool
                    doBeforeSaveFleetPool = function() {
                        return selectedFleetPool.isValid();
                    },
                    //event handler for Saving Fleet Pool
                    onSaveFleetPool = function() {
                        if (doBeforeSaveFleetPool()) {
                            saveFleetPool();
                        }
                    },
                    //add new fleetpool
                    saveFleetPool = function() {
                        if (isEditMode()) {
                            isEditMode(false);
                            dataservice.updateFleetPool({
                                FleetPoolId: selectedFleetPool().id(),
                                CountryId: newCountryFilter(),
                                RegionId: newRegionFilter(),
                                OperationId: newOperationFilter(),
                                FleetPoolCode: fleetPoolCode(),
                                FleetPoolName: fleetPoolName(),
                                ApproximateVehiclesAsgnd: fleetPoolVehicles(),
                                FleetPoolDescription: fleetPoolDescription()
                            }, {
                                success: function(data) {
                                    var updatedFleetPool = model.fleetPoolServertoClinetMapper(data);
                                    var fleetPool = selectedFleetPool();
                                    fleetPools.replace(fleetPool, updatedFleetPool);
                                    reset();
                                    toastr.success("Successfully upadted!");
                                },
                                error: function() {
                                    toastr.error("Failed to upadte!");
                                }
                            });
                        }
                        dataservice.saveFleetPool({
                            CountryId: newCountryFilter(),
                            RegionId: newRegionFilter(),
                            OperationId: newOperationFilter(),
                            FleetPoolCode: fleetPoolCode(),
                            FleetPoolName: fleetPoolName(),
                            ApproximateVehiclesAsgnd: fleetPoolVehicles(),
                            FleetPoolDescription: fleetPoolDescription()
                        }, {
                            success: function(data) {
                                reset();
                                toastr.success("Successfully added!");
                            },
                            error: function() {
                                toastr.error("Failed to add!");
                            }
                        });
                    },
                    //search Fleet Pools
                    search = function() {
                        pager().reset();
                        getFleetPools();
                    },
                    reset = function() {
                        fleetPoolSeachFilter(undefined);
                        fleetPoolRegionFilter(undefined);

                        fleetPoolOperationFilter(undefined);
                        search();                        
                    },
                    createFleetForm = function() { //parent
                        createPoolDetail();
                        showFleetPoolEditor();
                    },
                    //creating fleetpool details 
                    createPoolDetail = function() {
                        var temp = new model.FleetPoolDetail();
                    },
                    showFleetPoolEditor = function() {
                        newCountryFilter(undefined);
                        newOperationFilter(undefined);
                        newRegionFilter(undefined);
                        fleetPoolCode(undefined);
                        fleetPoolName(undefined);
                        fleetPoolVehicles(undefined);
                        fleetPoolDescription(undefined);

                        isFleetPoolEditorVisible(true);
                    },
                    // delete fleetpool
                    onDeleteFleetPool = function(item) {
                        if (!item.id()) {
                            fleetPools.remove(item);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function() {
                            deleteFleetPool(item);
                        });
                        confirmation.show();
                    },
                    // Delete Fleetpool request to daraservice
                    deleteFleetPool = function(asset) {
                        dataservice.deleteFleetPool(asset.convertToServerData(), {
                            success: function() {
                                fleetPools.remove(asset);
                                toastr.success("FleetPool removed successfully");
                            },
                            error: function() {
                                toastr.error("Failed to remove product!");
                            }
                        });
                    },
                    // on edit the existing fleet pool
                    onEditFleetPool = function(item) {
                        selectedFleetPool(item);
                        editFleetPool(item);                        
                    },
                    // Filter Regions
                    filterRegions = function (item, data) {
                        contryBaseRegionList(_.filter(regionsList(), function(region) {
                             return region.CountryId === item.countryId();
                        }));
                    },
                    // Map Tarrif Types - Server to Client
                    mapFleetPools = function(data) {
                        var fleetPoolList = [];
                        _.each(data.FleetPools, function(item) {
                            var fleetPool = model.fleetPoolServertoClinetMapper(item);
                            fleetPoolList.push(fleetPool);

                        });

                        ko.utils.arrayPushAll(fleetPools(), fleetPoolList);
                        fleetPools.valueHasMutated();
                    },
                    // Get FleetPools 
                    getFleetPools = function() {
                        isLoadingFleetPools(true);
                        dataservice.getFleetPools({
                            FleetPoolSearchText: fleetPoolSeachFilter(),
                            RegionId: fleetPoolRegionFilter(),
                            OperationId: fleetPoolOperationFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        }, {
                            success: function(data) {
                                pager().totalCount(data.TotalCount);
                                fleetPools.removeAll();
                                mapFleetPools(data);
                                isLoadingFleetPools(false);
                            },
                            error: function() {
                                isLoadingFleetPools(false);
                                toastr.error("Failed to load fleetPools!");
                            }
                        });
                    },
                    // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getFleetPoolBaseData(getFleetPools);
                        // Set Pager
                        pager(pagination.Pagination({}, fleetPools, getFleetPools));
                        getFleetPools();
                    },
                    // function to edit fleet pool
                    editFleetPool = function(item) {
                        isFleetPoolEditorVisible(true);                        
                    };
                    

                return {
                    isLoadingFleetPools: isLoadingFleetPools,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    pager: pager,
                    initialize: initialize,
                    regionsList: regionsList,
                    contryBaseRegionList: contryBaseRegionList,
                    operationsList: operationsList,
                    fleetPools: fleetPools,
                    selectedFleetPool: selectedFleetPool,
                    fleetPoolSeachFilter: fleetPoolSeachFilter,
                    fleetPoolOperationFilter: fleetPoolOperationFilter,
                    fleetPoolRegionFilter: fleetPoolRegionFilter,
                    search: search,
                    reset: reset,
                    isFleetPoolEditorVisible: isFleetPoolEditorVisible,
                    countrySelected: countrySelected,
                    countryList: countryList,
                    onDeleteFleetPool: onDeleteFleetPool,
                    onEditFleetPool: onEditFleetPool,
                    createFleetForm: createFleetForm,
                    ccreatePoolDetail: createPoolDetail,                    
                    showFleetPoolEditor: showFleetPoolEditor,                                        
                    cancelSave: cancelSave,                                        
                    onSaveFleetPool: onSaveFleetPool,
                    filterRegions: filterRegions
                };
            })()
        };
        return ist.fleetPool.viewModel;
    });
