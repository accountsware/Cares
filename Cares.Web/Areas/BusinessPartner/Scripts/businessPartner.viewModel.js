﻿/*
    Module with the view model for the Business Partner
*/
define("businessPartner/businessPartner.viewModel",
    ["jquery", "amplify", "ko", "businessPartner/businessPartner.dataservice", "businessPartner/businessPartnerWithKoMapping.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.businessPartner = {
            viewModel: (function () {
                var// the view 
                    view,
                    // Active BusinessPartner
                    selectedBusinessPartner = ko.observable(),
                     // listview selected BusinessPartner
                    listSelectedBusinessPartner = ko.observable(),
                    // #region Arrays
                    // BusinessPartners
                    businessPartners = ko.observableArray([]),
                    //categories = ko.observableArray([]),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingBusinessPartners = ko.observable(false),
                    // #endregion Busy Indicators
                    // #region Observables
                    // Companies Array
                    companies = ko.observableArray([]),
                    // Payment Terms Array 
                    paymentTerms = ko.observableArray([]),
                    // Business Partners Rating Types Array
                    bpRatingTypes = ko.observableArray([]),
                    // Business Legal Statuses Array
                    businessLegalStatuses = ko.observableArray([]),
                    // Response Business  Partners Array
                    respBusinessPartners = ko.observableArray([]),
                    // Business Legal Statuses Array
                    dealingEmployees = ko.observableArray([]),
                    // Business Partner Companies Array
                    businessPartnerCompanies = ko.observableArray([]),
                    // Countries Array
                    countries = ko.observableArray([]),
                    // Occupation Types Array
                    occupationTypes = ko.observableArray([]),
                    // Business Segments Array
                    businessSegments = ko.observableArray([]),
                     // Business Partner SubType Array
                    businessPartnerSubTypes = ko.observableArray([]),
                    // Phone Types Array
                    phoneTypes = ko.observableArray([]),
                    // Address Types Array
                    addressTypes = ko.observableArray([]),
                    // Country Regions Array
                    countryRegions = ko.observableArray([]),
                    // Country Regions Array
                    countryCitites = ko.observableArray([]),
                    // Sub Regions Array
                    subRegions = ko.observableArray([]),
                    // Filtered Sub Regions Array
                    filteredSubRegions = ko.observableArray([]),
                    // Filtered Country Cities Array
                    filteredCountryCities = ko.observableArray([]),
                    // Areas Array
                    areas = ko.observableArray([]),
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Is Business Partner Editor Visible
                    isBusinessPartnerEditorVisible = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                    // search filter
                    searchFilter = ko.observable(),
                    // select Filter
                    selectFilter = ko.observable(),
                    // selected Country from dropdown
                    selectedCountry = ko.observable(),
                    // #region Utility Functions
                    // Select filter option Individual or Company list
                    optionIndividualOrCompany = [{ Id: true, Name: 'Individual' },{Id : false, Name :  'Company'}],
                    // Select Gender list
                    optionGenderList = [{ Id: 'M', Name: 'Male' }, { Id: 'F', Name: 'Female' }],
                    // Select Martial Status list
                    optionMaritalStatusList = [
                        { Id: 'M', Name: 'Married' },
                        { Id: 'S', Name: 'Single' },
                         { Id: 'C', Name: 'Committed' },
                         { Id: 'D', Name: 'Divorced' },
                         { Id: 'W', Name: 'Widowed' }
                    ],
                    // Select business partner
                    selectBusinessPartner = function (businessPartner) {
                        if (listSelectedBusinessPartner() !== businessPartner) {
                            listSelectedBusinessPartner(businessPartner);
                        }
                    },
                     //For Edit, Tariff Type Id
                    selectedBusinessPartnerId = ko.observable(),
                    // Edit a Business Partner - In a Form
                    onEditBusinessPartner = function (businessPartner, e) {
                        selectedBusinessPartnerId(businessPartner.businessPartnerListId().split('-')[1]);
                        getBusinessPartnerById(selectedBusinessPartnerId());
                        showBusinessPartnerEditor();
                        e.stopImmediatePropagation();
                    },
                     //country selection change event
                    onCountrySelectionChange = function(value) {
                        getRegionsByCountry(value.countryId());
                    },
                    //get regions by country          
                    getRegionsByCountry = function (countryId) {
                        isLoadingBusinessPartners(true);
                        dataservice.getCountryRegions({
                            id: countryId
                        }, {
                            success: function (data) {
                                //country Regions array
                                countryRegions.removeAll();
                                ko.utils.arrayPushAll(countryRegions(), data.ResponseRegions);
                                countryRegions.valueHasMutated();
                                //country Cities array
                                countryCitites.removeAll();
                                ko.utils.arrayPushAll(countryCitites(), data.ResponseCities);
                                countryCitites.valueHasMutated();
                                //filtered Country Cities
                                filteredCountryCities.removeAll();
                                ko.utils.arrayPushAll(filteredCountryCities(), data.ResponseCities);
                                filteredCountryCities.valueHasMutated();
                                //Sub Regions array
                                subRegions.removeAll();
                                ko.utils.arrayPushAll(subRegions(), data.ResponseSubRegions);
                                subRegions.valueHasMutated();
                                //Area array
                                areas.removeAll();
                                ko.utils.arrayPushAll(areas(), data.ResponseAreas);
                                areas.valueHasMutated();
                                isLoadingBusinessPartners(false);
                            },
                            error: function () {
                                toastr.error("Failed to load regions!");
                            }
                        });
                    },
                    //region selection change event
                    onRegionSelectionChange = function (value) {
                        getSubRegionsByRegion(value.regionId());
                    },
                    //get sub regions by region          
                    getSubRegionsByRegion = function (regionId) {
                        isLoadingBusinessPartners(true);
                        // get filtered sub regions
                        filteredSubRegions.removeAll();
                        _.each(subRegions(), function (item) {
                            if (item.RegionId == regionId)
                                filteredSubRegions.push(item);
                        });
                        filteredSubRegions.valueHasMutated();
                        // get filtered cities
                        filteredCountryCities.removeAll();
                        _.each(countryCitites(), function (item) {
                            if (item.RegionId == regionId)
                                filteredCountryCities.push(item);
                        });
                        filteredCountryCities.valueHasMutated();
                        isLoadingBusinessPartners(false);
                    },
                    //sub region selection change event
                    onSubRegionSelectionChange = function (value) {
                        getCitiesBySubRegion(value.subRegionId());
                    },
                    //get cities by sub region          
                    getCitiesBySubRegion = function (subRegionId) {
                        isLoadingBusinessPartners(true);
                        // get filtered cities
                        filteredCountryCities.removeAll();
                        _.each(countryCitites(), function (item) {
                            if (item.SubRegionId == subRegionId)
                                filteredCountryCities.push(item);
                        });
                        filteredCountryCities.valueHasMutated();
                        isLoadingBusinessPartners(false);
                    },
                    // get business partner by id
                    getBusinessPartnerById = function (businessPartnerId) {
                        isLoadingBusinessPartners(true);
                        dataservice.getBusinessPartnerById({
                            id: businessPartnerId
                        }, {
                            success: function (data) {
                                selectedBusinessPartner(model.BusinessPartnerClientMapper(data));
                                selectedBusinessPartner().reset();
                                isLoadingBusinessPartners(false);
                            },
                            error: function () {
                                isLoadingBusinessPartners(false);
                                toastr.error("Error!");
                            }
                        });
                    },
                    // Show BusinessPartner Editor
                    showBusinessPartnerEditor = function () {
                        isBusinessPartnerEditorVisible(true);
                    },
                    // close BusinessPartner Editor
                    onCloseBusinessPartnerEditor = function () {
                        if (selectedBusinessPartner().hasChanges()) {
                            confirmation.messageText("Do you want to save changes?");
                            confirmation.afterProceed(onSaveBusinessPartner);
                            confirmation.afterCancel(function() {
                                selectedBusinessPartner().reset();
                                closeBusinessPartnerEditor();
                            });
                            confirmation.show();
                            return;
                        }
                        closeBusinessPartnerEditor();
                    },
                    // close Business Partner Editor
                    closeBusinessPartnerEditor = function () {
                        isBusinessPartnerEditorVisible(false);
                    },
                    // Delete a BusinessPartner
                    onDeleteBusinessPartner = function (businessPartner) {
                        if (!businessPartner.id()) {
                            businessPartners.remove(businessPartner);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function() {
                            deleteBusinessPartner(businessPartner);
                        });
                        confirmation.show();
                    },
                    // Delete a BusinessPartner In Type
                    onDeleteBusinessPartnerInType = function (businessPartnerInType) {
                           selectedBusinessPartner().businessPartnerInTypes.remove(businessPartnerInType);
                            return;
                    },
                    // Delete a BusinessPartner Phone Item
                    onDeleteBusinessPartnerPhone = function (businessPartnerPhone) {
                        selectedBusinessPartner().businessPartnerPhoneNumbers.remove(businessPartnerPhone);
                        return;
                    },
                    // Delete a BusinessPartner Address Item
                    onDeleteBusinessPartnerAddress = function (businessPartnerAddress) {
                        selectedBusinessPartner().businessPartnerAddressList.remove(businessPartnerAddress);
                        return;
                    },
                    // business partner InType selected subtype id computed
                    businessPartnerTypeSelectedSubTypeIdComputed = ko.computed(function () {
                        if (selectedBusinessPartner() != undefined && selectedBusinessPartner().businessPartnerInTypeNew().businessPartnerSubTypeId() != undefined && selectedBusinessPartner().businessPartnerInTypeNew().businessPartnerSubTypeId().split('-').length == 3)
                            return selectedBusinessPartner().businessPartnerInTypeNew().businessPartnerSubTypeId().split('-')[0];
                        else {
                            return undefined;
                        }
                    }),
                    // business partner intype selected subtype name computed
                    businessPartnerTypeSelectedSubTypeNameComputed = ko.computed(function () {
                        if (selectedBusinessPartner() != undefined && selectedBusinessPartner().businessPartnerInTypeNew().businessPartnerSubTypeId() != undefined && selectedBusinessPartner().businessPartnerInTypeNew().businessPartnerSubTypeId().split('-').length == 3)
                            return selectedBusinessPartner().businessPartnerInTypeNew().businessPartnerSubTypeId().split('-')[1] + '-' + selectedBusinessPartner().businessPartnerInTypeNew().businessPartnerSubTypeId().split('-')[2];
                        else {
                            return undefined;
                        }
                    }),
                    // business partner intype selected rating id computed
                    businessPartnerTypeSelecedBpRatingIdComputed = ko.computed(function() {
                        if (selectedBusinessPartner() != undefined && selectedBusinessPartner().businessPartnerInTypeNew().bpRatingTypeId() != undefined && selectedBusinessPartner().businessPartnerInTypeNew().bpRatingTypeId().split('-').length == 3)
                            return selectedBusinessPartner().businessPartnerInTypeNew().bpRatingTypeId().split('-')[0];
                        else {
                            return undefined;
                        }
                    }),
                    // business partner intype selected rating name computed
                    businessPartnerTypeSelecedBpRatingNameComputed = ko.computed(function () {
                        if (selectedBusinessPartner() != undefined && selectedBusinessPartner().businessPartnerInTypeNew().bpRatingTypeId() != undefined && selectedBusinessPartner().businessPartnerInTypeNew().bpRatingTypeId().split('-').length == 3)
                            return selectedBusinessPartner().businessPartnerInTypeNew().bpRatingTypeId().split('-')[1] + '-' + selectedBusinessPartner().businessPartnerInTypeNew().bpRatingTypeId().split('-')[2];
                        else {
                            return undefined;
                        }
                    }),
                    // business partner phone selected phone type id computed
                    businessPartnerPhoneSelecedPhoneTypeIdComputed = ko.computed(function() {
                        if (selectedBusinessPartner() != undefined && selectedBusinessPartner().businessPartnerPhoneNumberNew().phoneTypeId() != undefined && selectedBusinessPartner().businessPartnerPhoneNumberNew().phoneTypeId().split('-').length == 3)
                            return selectedBusinessPartner().businessPartnerPhoneNumberNew().phoneTypeId().split('-')[0];
                        else {
                            return undefined;
                        }
                    }),
                    // business partner phone selected phone type name computed
                    businessPartnerPhoneSelecedPhoneTypeNameComputed = ko.computed(function () {
                        if (selectedBusinessPartner() != undefined && selectedBusinessPartner().businessPartnerPhoneNumberNew().phoneTypeId() != undefined && selectedBusinessPartner().businessPartnerPhoneNumberNew().phoneTypeId().split('-').length == 3)
                            return selectedBusinessPartner().businessPartnerPhoneNumberNew().phoneTypeId().split('-')[1] + '-' + selectedBusinessPartner().businessPartnerPhoneNumberNew().phoneTypeId().split('-')[2];
                        else {
                            return undefined;
                        }
                    }),
                     // Do Before Add BusinessPartner InType Item
                    doBeforeAddItem = function () {
                        var flag = true;
                        if (!selectedBusinessPartner().businessPartnerInTypeNew().isValid()) {
                            selectedBusinessPartner().businessPartnerInTypeNew().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Add a BusinessPartner In Type
                    onAddBusinessPartnerInType = function () {
                        // check validation error before add
                        if (doBeforeAddItem()) {
                            var businessPartnerInType = model.BusinessPartnerInType(undefined, '', selectedBusinessPartner().businessPartnerInTypeNew().fromDate(), selectedBusinessPartner().businessPartnerInTypeNew().fromDate(), selectedBusinessPartner().businessPartnerId(), businessPartnerTypeSelectedSubTypeIdComputed(), businessPartnerTypeSelectedSubTypeNameComputed(), businessPartnerTypeSelecedBpRatingIdComputed(), businessPartnerTypeSelecedBpRatingNameComputed());
                            selectedBusinessPartner().businessPartnerInTypes.push(businessPartnerInType);
                            selectedBusinessPartner().businessPartnerInTypes.valueHasMutated();

                            // emplty input fields
                            selectedBusinessPartner().businessPartnerInTypeNew(model.BusinessPartnerInType(undefined, '', undefined, undefined, undefined, undefined, undefined, undefined, undefined));
                        }
                    },
                    // Do Before Add BusinessPartner Phone Item
                    doBeforeAddPhoneItem = function () {
                        var flag = true;
                        if (!selectedBusinessPartner().businessPartnerPhoneNumberNew().isValid()) {
                            selectedBusinessPartner().businessPartnerPhoneNumberNew().errors.showAllMessages();
                            flag = false;
                        } else {
                            // check if isdefault true entry already there
                            var isDefaultAlreadyThere = false;
                            _.each(selectedBusinessPartner().businessPartnerPhoneNumbers(), function(item) {
                                if (item.isDefault() == true)
                                    isDefaultAlreadyThere = true;
                            });
                            if (isDefaultAlreadyThere) {
                                toastr.info("Default record already there!");
                                return false;
                            }
                        }
                        return flag;
                    },
                    // Add a BusinessPartner Phone
                    onAddBusinessPartnerPhone = function () {
                        // check validation error before add
                        if (doBeforeAddPhoneItem()) {
                            var businessPartnerPhone = model.BusinessPartnerPhone(undefined, selectedBusinessPartner().businessPartnerPhoneNumberNew().isDefault(), selectedBusinessPartner().businessPartnerPhoneNumberNew().phoneNumber(), selectedBusinessPartner().businessPartnerId(), businessPartnerPhoneSelecedPhoneTypeIdComputed(), businessPartnerPhoneSelecedPhoneTypeNameComputed());
                            selectedBusinessPartner().businessPartnerPhoneNumbers.push(businessPartnerPhone);
                            selectedBusinessPartner().businessPartnerPhoneNumbers.valueHasMutated();
                            
                            // emplty input fields
                            selectedBusinessPartner().businessPartnerPhoneNumberNew(model.BusinessPartnerPhone(undefined,false,undefined,undefined,undefined));
                        }
                    },
                    // Do Before Add BusinessPartner Address Item
                    doBeforeAddAddressItem = function () {
                        var flag = true;
                        if (!selectedBusinessPartner().businessPartnerAddressNew().isValid()) {
                            selectedBusinessPartner().businessPartnerAddressNew().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Add a BusinessPartner Address
                    onAddBusinessPartnerAddress = function () {
                        // check validation error before add
                        if (doBeforeAddAddressItem()) {
                            var businessPartnerAddress = model.BusinessPartnerAddress(undefined, selectedBusinessPartner().businessPartnerAddressNew().contactPerson(), selectedBusinessPartner().businessPartnerAddressNew().streetAddress(), selectedBusinessPartner().businessPartnerAddressNew().emailAddress(), selectedBusinessPartner().businessPartnerAddressNew().webPage(), selectedBusinessPartner().businessPartnerAddressNew().zipCode(), selectedBusinessPartner().businessPartnerAddressNew().poBox(),selectedBusinessPartner().businessPartnerAddressNew().countryId(),"", undefined, undefined, undefined,undefined,undefined,undefined,undefined,undefined, selectedBusinessPartner().businessPartnerAddressNew().addressTypeId(),"", selectedBusinessPartner().businessPartnerId());
                            selectedBusinessPartner().businessPartnerAddressList.push(businessPartnerAddress);
                            selectedBusinessPartner().businessPartnerAddressList.valueHasMutated();

                            // emplty input fields
                            selectedBusinessPartner().businessPartnerAddressNew(model.BusinessPartnerAddress(undefined,"","","","","","",undefined,undefined,undefined,undefined,undefined,undefined,undefined,undefined,undefined,undefined,undefined,undefined,undefined));
                        }
                    },
                    // Create Business Partner
                    createBusinessPartner = function () {
                        var businessPartner = model.BusinessPartnerDetail.Create();
                        selectedBusinessPartner(businessPartner);
                    },
                    // Create BusinessPartner - In Form
                    createBusinessPartnerInForm = function () {
                        createBusinessPartner();
                        showBusinessPartnerEditor();
                    },
                    // Save BusinessPartner
                    onSaveBusinessPartner = function (businessPartner) {
                        if (doBeforeSave()) {
                            // Commits and Selects the Row
                            saveBusinessPartner(businessPartner);
                        }
                    },
                    // Do Before Logic
                    doBeforeSave = function() {
                        var flag = true;
                        if (!selectedBusinessPartner().isValid()) {
                            selectedBusinessPartner().errors.showAllMessages();
                            selectedBusinessPartner().businessPartnerIndividual().errors.showAllMessages();
                            selectedBusinessPartner().businessPartnerCompany().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Initialize the view model
                    initialize = function(specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                        pager(pagination.Pagination({}, businessPartners, getBusinessPartners));
                        getBusinessPartners();
                    },
                    // Map BusinessPartners - Server to Client
                    mapBusinessPartners = function (data) {
                        var businessPartnerList = [];
                        _.each(data.BusinessPartners, function (item) {
                            var businessPartner = new model.BusinessPartner(item);
                            businessPartnerList.push(businessPartner);
                        });                  
                        ko.utils.arrayPushAll(businessPartners(), businessPartnerList);
                        businessPartners.valueHasMutated();
                    },
                    // Get Base
                    getBase = function () {
                        dataservice.getBusinessPartnerBase({
                            success: function (data) {
                                //Company array
                                companies.removeAll();
                                ko.utils.arrayPushAll(companies(), data.ResponseCompanies);
                                companies.valueHasMutated();
                                // Payment Terms array
                                paymentTerms.removeAll();
                                ko.utils.arrayPushAll(paymentTerms(), data.ResponsePaymentTerms);
                                paymentTerms.valueHasMutated();
                                // Business Partner Rating Types array
                                bpRatingTypes.removeAll();
                                ko.utils.arrayPushAll(bpRatingTypes(), data.ResponseBPRatingTypes);
                                bpRatingTypes.valueHasMutated();
                                // Business Legal Statuses array
                                businessLegalStatuses.removeAll();
                                ko.utils.arrayPushAll(businessLegalStatuses(), data.ResponseBusinessLegalStatuses);
                                businessLegalStatuses.valueHasMutated();
                                // Business Legal Statuses array
                                respBusinessPartners.removeAll();
                                ko.utils.arrayPushAll(respBusinessPartners(), data.ResponseBusinessPartners);
                                respBusinessPartners.valueHasMutated();
                                // Business Legal Statuses array
                                dealingEmployees.removeAll();
                                ko.utils.arrayPushAll(dealingEmployees(), data.ResponseDealingEmployees);
                                dealingEmployees.valueHasMutated();
                                // Business Partner Companies array
                                businessPartnerCompanies.removeAll();
                                ko.utils.arrayPushAll(businessPartnerCompanies(), data.ResponseBusinessPartnerCompanies);
                                businessPartnerCompanies.valueHasMutated();
                                // Countries array
                                countries.removeAll();
                                ko.utils.arrayPushAll(countries(), data.ResponseCountries);
                                countries.valueHasMutated();
                                // Occupation Types array
                                occupationTypes.removeAll();
                                ko.utils.arrayPushAll(occupationTypes(), data.ResponseOccupationTypes);
                                occupationTypes.valueHasMutated();
                                // Business Segments array
                                businessSegments.removeAll();
                                ko.utils.arrayPushAll(businessSegments(), data.ResponseBusinessSegments);
                                businessSegments.valueHasMutated();
                                // Business Partner SubType array
                                businessPartnerSubTypes.removeAll();
                                ko.utils.arrayPushAll(businessPartnerSubTypes(), data.ResponseBusinessPartnerSubTypes);
                                businessPartnerSubTypes.valueHasMutated();
                                // Phone Types array
                                phoneTypes.removeAll();
                                ko.utils.arrayPushAll(phoneTypes(), data.ResponsePhoneTypes);
                                phoneTypes.valueHasMutated();
                                // Address Types array
                                addressTypes.removeAll();
                                ko.utils.arrayPushAll(addressTypes(), data.ResponseAddressTypes);
                                addressTypes.valueHasMutated();
                            },
                            error: function () {
                                toastr.error("Failed to load base data");
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getBusinessPartners();
                    },
                    // Get businessPartners
                    getBusinessPartners = function () {
                        isLoadingBusinessPartners(true);
                        dataservice.getBusinessPartners({
                            SearchString: searchFilter(),
                            SelectOption: selectFilter(),  
                            PageNo: pager().currentPage(), SortBy: sortOn(), IsAsc: sortIsAsc() 
                        }, {
                            success: function(data) {
                                pager().totalCount(data.TotalCount);
                                businessPartners.removeAll();
                                mapBusinessPartners(data);
                                isLoadingBusinessPartners(false);
                            },
                            error: function() {
                                isLoadingBusinessPartners(false);
                                toastr.error("Failed to load businessPartners!");
                            }
                        });
                    },
                    // Delete BusinessPartner
                    deleteBusinessPartner = function (businessPartner) {
                        dataservice.deleteBusinessPartner(businessPartner.convertToServerData(), {
                            success: function () {
                                businessPartners.remove(businessPartner);
                                toastr.success("Business Partner removed successfully");
                            },
                            error: function () {
                                toastr.error("Failed to remove Business Partner!");
                            }
                        });
                    },
                    // Save Business Partner
                    saveBusinessPartner = function (businessPartner) {
                        var method = "updateBusinessPartner";
                        if (!selectedBusinessPartner().businessPartnerId()) {
                            method = "createBusinessPartner";
                        }
                        dataservice[method](model.BusinessPartnerServerMapper(selectedBusinessPartner()), {
                            success: function () {
                                // Reset Changes
                                selectedBusinessPartner().reset();
                                // If BusinessPartner is specified then select it
                                if (businessPartner) {
                                    selectBusinessPartner(businessPartner);
                                }
                                if (isBusinessPartnerEditorVisible) {
                                    closeBusinessPartnerEditor();
                                }
                                getBusinessPartners();
                                toastr.success("Business Partner saved successfully");
                            },
                            error: function () {
                                toastr.error('Failed to save business Partner!');
                            }
                        });
                    };
                // #endregion Service Calls
                return {
                    // Observables
                    selectedBusinessPartner: selectedBusinessPartner,
                    isLoadingBusinessPartners: isLoadingBusinessPartners,
                    businessPartners: businessPartners,
                    searchFilter: searchFilter,
                    selectFilter: selectFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    // Observables Arrays
                    companies: companies,
                    paymentTerms: paymentTerms,
                    bpRatingTypes: bpRatingTypes,
                    businessLegalStatuses: businessLegalStatuses,
                    respBusinessPartners: respBusinessPartners,
                    dealingEmployees: dealingEmployees,
                    businessPartnerCompanies: businessPartnerCompanies,
                    countries: countries,
                    occupationTypes: occupationTypes,
                    businessSegments: businessSegments,
                    businessPartnerSubTypes: businessPartnerSubTypes,
                    phoneTypes: phoneTypes,
                    addressTypes:addressTypes,
                    // Utility Methods
                    onSaveBusinessPartner: onSaveBusinessPartner,
                    createBusinessPartner: createBusinessPartner,
                    onDeleteBusinessPartner: onDeleteBusinessPartner,
                    initialize: initialize,
                    selectBusinessPartner: selectBusinessPartner,
                    search: search,
                    getBusinessPartners: getBusinessPartners,
                    pager: pager,
                    onEditBusinessPartner: onEditBusinessPartner,
                    showBusinessPartnerEditor: showBusinessPartnerEditor,
                    onCloseBusinessPartnerEditor: onCloseBusinessPartnerEditor,
                    isBusinessPartnerEditorVisible: isBusinessPartnerEditorVisible,
                    createBusinessPartnerInForm: createBusinessPartnerInForm,
                    optionIndividualOrCompany: optionIndividualOrCompany,
                    listSelectedBusinessPartner: listSelectedBusinessPartner,      
                    optionGenderList: optionGenderList,
                    optionMaritalStatusList: optionMaritalStatusList,
                    onDeleteBusinessPartnerInType: onDeleteBusinessPartnerInType,
                    onAddBusinessPartnerInType: onAddBusinessPartnerInType,
                    doBeforeAddPhoneItem: doBeforeAddPhoneItem,
                    onAddBusinessPartnerPhone: onAddBusinessPartnerPhone,
                    onDeleteBusinessPartnerPhone: onDeleteBusinessPartnerPhone,
                    doBeforeAddAddressItem: doBeforeAddAddressItem,
                    onAddBusinessPartnerAddress: onAddBusinessPartnerAddress,
                    onDeleteBusinessPartnerAddress: onDeleteBusinessPartnerAddress,
                    onCountrySelectionChange: onCountrySelectionChange,
                    selectedCountry: selectedCountry,
                    countryRegions: countryRegions,
                    countryCitites: countryCitites,
                    onRegionSelectionChange: onRegionSelectionChange,
                    subRegions: subRegions,
                    areas: areas,
                    filteredSubRegions: filteredSubRegions,
                    filteredCountryCities: filteredCountryCities,
                    onSubRegionSelectionChange:onSubRegionSelectionChange
                    //filteredAreas: filteredAreas,
                    // Utility Methods
                };
            })()
        };
        return ist.businessPartner.viewModel;
    });
