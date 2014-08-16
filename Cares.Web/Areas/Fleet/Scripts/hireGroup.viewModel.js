﻿/*
    Module with the view model for the Hire Group
*/
define("hireGroup/hireGroup.viewModel",
    ["jquery", "amplify", "ko", "hireGroup/hireGroup.dataservice", "hireGroup/hireGroup.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.hireGroup = {
            viewModel: (function () {
                var // the view 
                    view,
                     // Active Hire Group
                   selectedHireGroup = ko.observable(),
                    //Active Hire Group Copy 
                   selectedHireGroupCopy = ko.observable(),
                    //Active Hire Group Id
                    selectedHireGroupId = ko.observable(),
                   // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // #region Arrays
                    // Companies
                    companies = ko.observableArray([]),
                      //Hire Groups
                    hireGroups = ko.observableArray([]),
                    // Parent Hire Groups
                    parentHireGroups = ko.observableArray([]),
                    // Filter Parent Hire Groups
                    filteredParentHireGroups = ko.observableArray([]),
                    //Filter Hire Group on base of compny
                    filteredHireGroups = ko.observableArray([]),
                     //Vehicle Make
                    vehicleMakes = ko.observableArray([]),
                    //Vehicle Models
                    vehicleModels = ko.observableArray([]),
                    //Vehicle Categories
                    vehicleCategories = ko.observableArray([]),
                    //Hire Group Deatil List
                    hireGroupDetails = ko.observableArray([]),
                    //Hire Group Up Grade List
                    hireGroupUpGradeList = ko.observableArray([]),
                      //Hire Group upgraded tab 
                    hireGroupsForDdList = ko.observableArray([]),
                    //Filtered Hire Group list based on company For drop-down list
                    filteredHireGroupsForDdList = ko.observableArray([]),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingHireGroups = ko.observable(false),
                    // #endregion Busy Indicators
                    // #region Observables
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Sort On Hiregroup
                    sortOnHg = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAscHg = ko.observable(true),
                    // Is HIre Group Editor Visible
                    isHireGroupEditorVisible = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                     //Hire Group Code filter
                    hireGroupCodeFilter = ko.observable(),
                    //Hire Group Name  Filter
                    hireGroupNameFilter = ko.observable(),
                    // Company Filter
                    companyFilter = ko.observable(),
                    //Parent Hire Group Filter
                    parentHireGroupFilter = ko.observable(),
                    // #region Utility Functions
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBaseData();
                        // Set Pager
                        pager(new pagination.Pagination({}, hireGroups, getHireGroup));
                        getHireGroup();

                    },
                     // Collapase filter section
                    collapseFilterSection = function () {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function () {
                        filterSectionVisilble(true);
                    },
                    //close Hire Group Editor
                    closeHireGroupEditor = function () {
                        isHireGroupEditorVisible(false);
                    },
                    //Show Hire Group Editor
                    showHireGroupEditor = function () {
                        isHireGroupEditorVisible(true);
                    },
                     //Create Hire Group Rate
                    createHireGroup = function () {
                        var hireGroup = new model.HireGroup();
                        hireGroupDetails.removeAll();
                        hireGroupUpGradeList.removeAll();
                        // Select the newly added Hire Group
                        selectedHireGroup(hireGroup);
                        selectedHireGroup().vehicleDetail(new model.HireGroupDetail());
                        selectedHireGroup().hireGroupUpGrade(new model.HireGroupUpGrade());
                        showHireGroupEditor();
                    },
                      //Edit Hire Group
                    onEditHireGroup = function (hireGroup, e) {
                        hireGroupDetails.removeAll();
                        hireGroupUpGradeList.removeAll();
                        selectedHireGroup(hireGroup);
                        selectedHireGroupId(hireGroup.hireGroupId());
                        selectedHireGroup().vehicleDetail(new model.HireGroupDetail());
                        selectedHireGroup().hireGroupUpGrade(new model.HireGroupUpGrade());
                        //selectedtariffRateCopy(model.TariffRateCoppier(selectedtariffRate()));
                        getHireGroupById();
                        showHireGroupEditor();
                        e.stopImmediatePropagation();
                    },
                     //Get Hire Group data By Id
                    getHireGroupById = function () {
                        isLoadingHireGroups(true);
                        dataservice.getHireGroupDetailById({
                            id: selectedHireGroupId()

                        }, {
                            success: function (data) {
                                var hirGroupDetailItems = [];
                                //Hire Group Details
                                _.each(data.HireGroupDetails, function (item) {
                                    hirGroupDetailItems.push(model.HireGroupDetailClientMapper(item));
                                });
                                ko.utils.arrayPushAll(hireGroupDetails(), hirGroupDetailItems);
                                hireGroupDetails.valueHasMutated();
                                //Up grade Hire Group
                                _.each(data.HireGroupUpGrades, function (item) {
                                    hireGroupUpGradeList.push(model.HireGroupUpGradeClientMapper(item));
                                });
                                hireGroupUpGradeList.valueHasMutated();
                                isLoadingHireGroups(false);
                            },
                            error: function () {
                                isLoadingHireGroups(false);
                                toastr.error("Error!");
                            }
                        });
                    },
                    //country selected form dd
                    onSelectedCompany = function (companyId) {
                        // get filtered parent hire groups based on company id
                        filteredParentHireGroups.removeAll();
                        _.each(parentHireGroups(), function (item) {
                            if (item.CompanyId === companyId.companyId())
                                filteredParentHireGroups.push(item);
                        });
                        filteredParentHireGroups.valueHasMutated();
                        filteredHireGroupsForDdList.removeAll();
                        _.each(hireGroupsForDdList(), function (item) {
                            if (item.CompanyId === companyId.companyId())
                                filteredHireGroupsForDdList.push(item);
                        });
                        filteredHireGroupsForDdList.valueHasMutated();
                    },
                     //On Vehicle Make Change
                    onVehicleMakeChange = function (vehicleMake) {
                        if (vehicleMake.vehicleMakeId() !== undefined) {
                            selectedHireGroup().vehicleDetail().vehicleMakeName(vehicleMake.vehicleMakeId().VehicleMakeCodeName);
                            selectedHireGroup().vehicleDetail().vehicleMakeId(vehicleMake.vehicleMakeId().VehicleMakeId);
                        }
                    },
                      //On Vehicle Category Change
                    onVehicleCategoryChange = function (vehicelCategory) {
                        if (vehicelCategory.vehicleCategoryId() !== undefined) {
                            selectedHireGroup().vehicleDetail().vehicleCategoryName(vehicelCategory.vehicleCategoryId().VehicleCategoryCodeName);
                            selectedHireGroup().vehicleDetail().vehicleCategoryId(vehicelCategory.vehicleCategoryId().VehicleCategoryId);
                        }
                    },
                      //On Vehicle Model Change
                    onVehicleModelChange = function (vehicelModel) {
                        if (vehicelModel.vehicleModelId() !== undefined) {
                            selectedHireGroup().vehicleDetail().vehicleModelName(vehicelModel.vehicleModelId().VehicleModelCodeName);
                            selectedHireGroup().vehicleDetail().vehicleModelId(vehicelModel.vehicleModelId().VehicleModeld);
                        }
                    },
                       // Add To list vehicle detail
                    onAddVehicleDetail = function (vehicleDetail) {
                        if (doBeforeAdd()) {
                            hireGroupDetails.push(model.HireGroupDetailCopier(vehicleDetail));
                        }
                    },
                      // Add To list HIre Group Up Grade
                    onAddHireGroupUpGrade = function (vehicleDetail) {
                        if (doBeforeAddHireGroupUpGrade()) {
                            hireGroupUpGradeList.push(model.HireGroupUpGradeClientMapper(vehicleDetail.hireGroupIdForUpGrade()));
                        }
                    },
                     // Delete a Hire Group
                    onDeleteHireGroup = function (hireGroup) {
                        if (!hireGroup.hireGroupId()) {
                            //hireGroups.remove(hireGroup);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteHireGroup(hireGroup);
                        });
                        confirmation.show();
                    },
                    // Delete Hire Group
                    deleteHireGroup = function (hireGroup) {
                        dataservice.deleteHireGroup(model.HireGroupServerMapper(hireGroup), {
                            success: function () {
                                hireGroups.remove(hireGroup);
                                toastr.success("Hire Group removed successfully");
                            },
                            error: function () {
                                toastr.error("Failed to remove Hire Group!");
                            }
                        });
                    },
                      // Delete Hire Group Detail
                    deleteHireGroupDetail = function (hireGroup) {
                        hireGroupDetails.remove(hireGroup);
                    },
                      // Delete Hire Group Up Grade
                    deleteHireGroupUpGrade = function (hireGroup) {
                        hireGroupUpGradeList.remove(hireGroup);
                    },
                      // Do Before Logic
                    doBeforeAdd = function () {
                        var flag = true;
                        if (!selectedHireGroup().vehicleDetail().isValid()) {
                            selectedHireGroup().vehicleDetail().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                     // Do Before Logic
                    doBeforeAddHireGroupUpGrade = function () {
                        var flag = true;
                        if (!selectedHireGroup().hireGroupUpGrade().isValid()) {
                            selectedHireGroup().hireGroupUpGrade().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                      // Save Hire Group
                    onSaveHireGroup = function (hireGroup) {
                        if (doBeforeSave()) {
                            hireGroup.hireGroupDetailList.removeAll();
                            hireGroup.upgragedHireGroupList.removeAll();
                            _.each(hireGroupDetails(), function (item) {
                                hireGroup.hireGroupDetailList.push(model.HireGroupDetailServerMapper(item));
                            });
                            _.each(hireGroupUpGradeList(), function (item) {
                                hireGroup.upgragedHireGroupList.push(model.HireGroupUpGradeServerMapper(item));
                            });
                            saveHireGroup(hireGroup);
                        }
                    },
                       // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (!selectedHireGroup().isValid()) {
                            selectedHireGroup().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Save Hire Group
                    saveHireGroup = function (hireGroup) {
                        var method = "updateHireGroup";
                        if (!hireGroup.hireGroupId()) {
                            method = "createHireGroup";
                        }

                        dataservice[method](model.HireGroupServerMapper(hireGroup), {
                            success: function (data) {
                                var hireGroupResult = new model.HireGroupClientMapper(data);
                                if (selectedHireGroup().hireGroupId() === undefined) {
                                    hireGroups.splice(0, 0, hireGroupResult);
                                } else {
                                    selectedHireGroup().hireGroupCode(hireGroupResult.hireGroupCode());
                                    selectedHireGroup().hireGroupName(hireGroupResult.hireGroupName());
                                    selectedHireGroup().companyName(hireGroupResult.companyName());
                                    selectedHireGroup().companyId(hireGroupResult.companyId());
                                    selectedHireGroup().parentHireGroupId(hireGroupResult.parentHireGroupId());
                                    selectedHireGroup().isParent(hireGroupResult.isParent());
                                    selectedHireGroup().description(hireGroupResult.description());
                                    selectedHireGroup().virtualIsParent(hireGroupResult.isParent());

                                }
                                closeHireGroupEditor();
                                toastr.success("Hire Group saved successfully");
                            },
                            error: function () {
                                toastr.error('Failed to save Hire Group!');
                            }
                        });
                    },
                     //Get Base Data
                    getBaseData = function (callBack) {
                        dataservice.getHireGroupBase({
                            success: function (data) {
                                //Hire Groups
                                hireGroupsForDdList.removeAll();
                                ko.utils.arrayPushAll(hireGroupsForDdList(), data.HireGroups);
                                hireGroupsForDdList.valueHasMutated();
                                //Company array
                                companies.removeAll();
                                ko.utils.arrayPushAll(companies(), data.Companies);
                                companies.valueHasMutated();
                                //Vehicle Makes
                                vehicleMakes.removeAll();
                                ko.utils.arrayPushAll(vehicleMakes(), data.VehicleMakes);
                                vehicleMakes.valueHasMutated();
                                //Vehicle Categories
                                vehicleCategories.removeAll();
                                ko.utils.arrayPushAll(vehicleCategories(), data.VehicleCategories);
                                vehicleCategories.valueHasMutated();
                                //Vehicle Models
                                vehicleModels.removeAll();
                                ko.utils.arrayPushAll(vehicleModels(), data.VehicleModels);
                                vehicleModels.valueHasMutated();
                                //Parent Hire Groups
                                parentHireGroups.removeAll();
                                ko.utils.arrayPushAll(parentHireGroups(), data.ParentHireGroups);
                                parentHireGroups.valueHasMutated();
                                if (callBack && typeof callBack === 'function') {
                                    callBack();
                                }
                            },
                            error: function () {
                                toastr.error("Failed to load base data");
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getHireGroup();
                    },
                    mapHireGroups = function (data) {
                        var hireGroupList = [];
                        _.each(data.HireGroups, function (item) {
                            var hireGroup = new model.HireGroupClientMapper(item);
                            hireGroupList.push(hireGroup);
                        });
                        ko.utils.arrayPushAll(hireGroups(), hireGroupList);
                        hireGroups.valueHasMutated();
                    },
                    modelYears = [{ Id: 2001, Text: '2001' },
                        { Id: 2002, Text: '2002' },
                        { Id: 2003, Text: '2003' },
                         { Id: 2004, Text: '2004' },
                        { Id: 2005, Text: '2005' },
                        { Id: 2006, Text: '2006' },
                        { Id: 2007, Text: '2007' }



                    ],
                    // Get Hire Group
                    getHireGroup = function () {
                        isLoadingHireGroups(true);
                        dataservice.getHireGroup({
                            HireGroupCode: hireGroupCodeFilter(),
                            HireGroupName: hireGroupNameFilter,
                            CompanyId: companyFilter(),
                            ParentHireGroupId: parentHireGroupFilter(),
                            PageSize: pager().pageSize(),
                            PageNo: pager().currentPage(),
                            SortBy: sortOn(),
                            IsAsc: sortIsAsc()
                        }, {
                            success: function (data) {
                                pager().totalCount(data.TotalCount);
                                hireGroups.removeAll();
                                mapHireGroups(data);
                                isLoadingHireGroups(false);
                            },
                            error: function () {
                                isLoadingHireGroups(false);
                                toastr.error("Failed to load Hire Groups!");
                            }
                        });
                    };
                // #endregion Service Calls

                return {
                    // Observables
                    selectedHireGroup: selectedHireGroup,
                    selectedHireGroupCopy: selectedHireGroupCopy,
                    isLoadingHireGroups: isLoadingHireGroups,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    sortOnHg: sortOnHg,
                    sortIsAscHg: sortIsAscHg,
                    isHireGroupEditorVisible: isHireGroupEditorVisible,
                    filterSectionVisilble: filterSectionVisilble,
                    //Arrays
                    companies: companies,
                    parentHireGroups: parentHireGroups,
                    hireGroups: hireGroups,
                    vehicleMakes: vehicleMakes,
                    vehicleModels: vehicleModels,
                    vehicleCategories: vehicleCategories,
                    modelYears: modelYears,
                    hireGroupsForDdList: hireGroupsForDdList,
                    filteredHireGroupsForDdList: filteredHireGroupsForDdList,
                    filteredParentHireGroups: filteredParentHireGroups,
                    filteredHireGroups: filteredHireGroups,
                    hireGroupDetails: hireGroupDetails,
                    hireGroupUpGradeList: hireGroupUpGradeList,
                    //Filters
                    hireGroupCodeFilter: hireGroupCodeFilter,
                    hireGroupNameFilter: hireGroupNameFilter,
                    companyFilter: companyFilter,
                    parentHireGroupFilter: parentHireGroupFilter,
                    // Utility Methods
                    initialize: initialize,
                    search: search,
                    getHireGroup: getHireGroup,
                    mapHireGroups: mapHireGroups,
                    getBaseData: getBaseData,
                    pager: pager,
                    closeHireGroupEditor: closeHireGroupEditor,
                    showHireGroupEditor: showHireGroupEditor,
                    createHireGroup: createHireGroup,
                    onEditHireGroup: onEditHireGroup,
                    onSelectedCompany: onSelectedCompany,
                    onAddVehicleDetail: onAddVehicleDetail,
                    onAddHireGroupUpGrade: onAddHireGroupUpGrade,
                    onVehicleModelChange: onVehicleModelChange,
                    onVehicleMakeChange: onVehicleMakeChange,
                    onVehicleCategoryChange: onVehicleCategoryChange,
                    onSaveHireGroup: onSaveHireGroup,
                    onDeleteHireGroup: onDeleteHireGroup,
                    deleteHireGroupDetail: deleteHireGroupDetail,
                    deleteHireGroupUpGrade: deleteHireGroupUpGrade,
                    //selectHireGroup: selectHireGroup,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    // Utility Methods

                };
            })()
        };
        return ist.hireGroup.viewModel;
    });
