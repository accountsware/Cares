﻿/*
    View for the Rental Agreement. Used to keep the viewmodel clear of UI related logic
*/
define("rentalAgreement/rentalAgreement.view",
    ["jquery", "rentalAgreement/rentalAgreement.viewModel"], function ($, rentalAgreementViewModel) {

        var ist = window.ist || {};
        
        // View 
        ist.rentalAgreement.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#rentalAgreementBinding")[0],
                // Close Popover
                closePopover = function(popoverId) {
                    var element = $("#" + popoverId);
                    if (element) {
                        element.popover('hide');
                    }
                },
                // Expand Panel
                expandPanel = function (panelId) {
                    var element = $("#" + panelId);
                    if (element && !element.hasClass('collapse.in')) {
                        element.collapse('show');
                    }
                },
                // Show the dialog
                show = function () {
                    $("#hiregroupInsuranceDialog").modal("show");
                },
                // Hide the dialog
                hide = function () {
                    $("#hiregroupInsuranceDialog").modal("hide");
                },
                // Show the dialog
                showRaVehicleCheckListDialog = function (status) {
                    if (status) {
                        $("#raVehicleCheckListOutDialog").modal("show");
                    }
                    else {
                        $("#raVehicleCheckListInDialog").modal("show");
                    }
                },
                // Hide the dialog
                hideRaVehicleCheckListDialog = function (status) {
                    if (status) {
                        $("#raVehicleCheckListOutDialog").modal("hide");
                    }
                    else {
                        $("#raVehicleCheckListInDialog").modal("hide");
                    }
                },
                // Show Vehilce the dialog
                showVehicleDialog = function () {
                    $("#vehicleDialog").modal("show");
                },
                // Hide Vehicle the dialog
                hideVehicleDialog = function () {
                    $("#vehicleDialog").modal("hide");
                },
                // Show Extras the dialog
                showExtrasDialog = function () {
                    $("#serviceItemDialog").modal("show");
                },
                // Hide Extras the dialog
                hideExtrasDialog = function () {
                    $("#serviceItemDialog").modal("hide");
                },
                // Show Chauffer the dialog
                showChaufferDialog = function () {
                    $("#chaufferDialog").modal("show");
                },
                // Hide Chauffer the dialog
                hideChaufferDialog = function () {
                    $("#chaufferDialog").modal("hide");
                },
                // Show Damages the dialog
                showDamagesDialog = function () {
                    $("#additionalChargeDialog").modal("show");
                },
                // Hide Damages the dialog
                hideDamagesDialog = function () {
                    $("#additionalChargeDialog").modal("hide");
                },
                // Show Vehicle Movement the dialog
                showVehicleMovementDialog = function () {
                    $("#vehicleMovementDialog").modal("show");
                },
                // Hide Vehicle Movement the dialog
                hideVehicleMovementDialog = function () {
                    $("#vehicleMovementDialog").modal("hide");
                },
                // Show Discounts the dialog
                showDiscountsDialog = function () {
                    $("#discountsDialog").modal("show");
                },
                // Hide Discounts the dialog
                hideDiscountsDialog = function () {
                    $("#discountsDialog").modal("hide");
                },
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }

                    var hireGroups = new Bloodhound({
                        datumTokenizer: function (d) {
                            return Bloodhound.tokenizers.whitespace(d.hireGroup);
                        },
                        queryTokenizer: Bloodhound.tokenizers.whitespace,
                        remote: {
                            rateLimitWait: 1000,
                            url: ist.siteUrl + '/Api/RentalAgreementHireGroups?searchText=%QUERY&operationWorkPlaceId=%operation&startDtTime=%stdt&endDtTime=%enddt',
                            ajax: {
                               type: 'POST'
                            },
                            replace: function(url, query) {
                                return url.replace('%QUERY', query).replace('%operation', viewModel.rentalAgreement().openLocation())
                                .replace('%stdt', moment(viewModel.rentalAgreement().start()).format(ist.utcFormat) + 'Z')
                                .replace('%enddt', moment(viewModel.rentalAgreement().end()).format(ist.utcFormat) + 'Z');
                            },
                            filter: function (data) {
                                return _.map(data, function (hireGroup) {
                                    return viewModel.model.HireGroupDetail.Create(hireGroup);
                                });
                            }
                        }
                    });

                    hireGroups.initialize();

                    $('#rentalAgreementHireGroup').typeahead({
                        highlight: true
                    },
                    {
                        displayKey: 'hireGroup',
                        source: hireGroups.ttAdapter()
                    }).bind('typeahead:selected', function(obj, selected) {
                        if (selected) {
                            viewModel.selectHireGroup(selected);
                        }
                    });
                    
                };

            initialize();
           
            return {
                bindingRoot: bindingRoot,
                closePopover: closePopover,
                viewModel: viewModel,
                show: show,
                hide: hide,
                showRaVehicleCheckListDialog: showRaVehicleCheckListDialog,
                hideRaVehicleCheckListDialog: hideRaVehicleCheckListDialog,
                expandPanel: expandPanel,
                showVehicleDialog: showVehicleDialog,
                hideVehicleDialog: hideVehicleDialog,
                showDamagesDialog: showDamagesDialog,
                hideDamagesDialog: hideDamagesDialog,
                showExtrasDialog: showExtrasDialog,
                hideExtrasDialog: hideExtrasDialog,
                showChaufferDialog: showChaufferDialog,
                hideChaufferDialog: hideChaufferDialog,
                showVehicleMovementDialog: showVehicleMovementDialog,
                hideVehicleMovementDialog: hideVehicleMovementDialog,
                showDiscountsDialog: showDiscountsDialog,
                hideDiscountsDialog: hideDiscountsDialog
            };
        })(rentalAgreementViewModel);

        // Initialize the view model
        if (ist.rentalAgreement.view.bindingRoot) {
            rentalAgreementViewModel.initialize(ist.rentalAgreement.view);
        }

        return ist.rentalAgreement.view;
    });