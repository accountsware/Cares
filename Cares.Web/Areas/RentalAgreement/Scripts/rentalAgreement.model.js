﻿define(["ko", "underscore", "underscore-ko"], function (ko) {

    var

    // Vehicle entity
    // ReSharper disable InconsistentNaming
    Vehicle = function (specifiedId, specifiedName, specifiedCode, specifiedPlateNumber, specifiedCurrentOdometer, specifiedVehicleCategoryId,
        specifiedVehicleCategoryCodeName, specifiedVehicleMakeId, specifiedVehicleMakeCodeName, specifiedVehicleModelId, specifiedVehicleModelCodeName,
        specifiedVehicleStatusId, specifiedVehicleStatusCodeName, specifiedModelYear, specifiedImage, specifiedFuelLevel, specifiedTankSize) {
        // ReSharper restore InconsistentNaming

        var
            // Plate Number
            plateNumber = ko.observable(specifiedPlateNumber),
            // Tank Size
            tankSize = ko.observable(specifiedTankSize);

        return {
            id: specifiedId,
            name: specifiedName,
            code: specifiedCode,
            plateNumber: plateNumber,
            currentOdometer: specifiedCurrentOdometer,
            vehicleCategoryId: specifiedVehicleCategoryId,
            vehicleCategory: specifiedVehicleCategoryCodeName,
            vehicleMakeId: specifiedVehicleMakeId,
            vehicleMake: specifiedVehicleMakeCodeName,
            vehicleModelId: specifiedVehicleModelId,
            vehicleModel: specifiedVehicleModelCodeName,
            vehicleStatusId: specifiedVehicleStatusId,
            vehicleStatus: specifiedVehicleStatusCodeName,
            modelYear: specifiedModelYear,
            image: specifiedImage,
            fuelLevel: specifiedFuelLevel,
            tankSize: tankSize
        };
    },

    // Vehicle Movement entity
    // ReSharper disable InconsistentNaming
    VehicleMovement = function (specifiedId, specifiedRaHireGroupId, specifiedOperationsWorkPlaceId, specifiedVehicleStatusId,
        specifiedStatus, specifiedDtTime, specifiedOdometer, specifiedFuelLevel, specifiedVehicleCondition, specifiedVehicleConditionDescription) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // Ra HireGroup Id
            raHireGroupId = ko.observable(specifiedRaHireGroupId || 0),
            // Vehicle Status Id
            vehicleStatusId = ko.observable(specifiedVehicleStatusId),
            // Status
            status = ko.observable(specifiedStatus),
            // Odometer
            odometer = ko.observable(specifiedOdometer),
            // Fuel Level
            fuelLevel = ko.observable(specifiedFuelLevel),
            // Operations Workplace Id
            operationsWorkPlaceId = ko.observable(specifiedOperationsWorkPlaceId),
            // Vehicle Condition
            vehicleCondition = ko.observable(specifiedVehicleCondition),
            // Vehicle Condition Description
            vehicleConditionDescription = ko.observable(specifiedVehicleConditionDescription),
            // Start Date Time
            internalStartDateTime = ko.observable(specifiedDtTime || moment().toDate()),
            // Start Date
            start = ko.computed({
                read: function () {
                    return internalStartDateTime();
                },
                write: function (value) {
                    if (value === internalStartDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalStartDateTime(undefined);
                    } else {
                        internalStartDateTime(value);
                    }
                }
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    VehicleMovementId: id(),
                    RaHireGroupId: raHireGroupId(),
                    Status: status(),
                    Odometer: odometer(),
                    FuelLevel: fuelLevel(),
                    OperationsWorkPlaceId: operationsWorkPlaceId(),
                    VehicleCondition: vehicleCondition(),
                    DtTime: moment(start()).format(ist.utcFormat) + 'Z',
                    VehicleConditionDescription: vehicleConditionDescription(),
                    VehicleStatusId: vehicleStatusId()
                };
            };

        return {
            id: id,
            raHireGroupId: raHireGroupId,
            vehicleStatusId: vehicleStatusId,
            status: status,
            odometer: odometer,
            fuelLevel: fuelLevel,
            operationsWorkPlaceId: operationsWorkPlaceId,
            vehicleCondition: vehicleCondition,
            vehicleConditionDescription: vehicleConditionDescription,
            start: start,
            convertToServerData: convertToServerData
        };
    },

    // Payment Term entity
    // ReSharper disable InconsistentNaming
    PaymentTerm = function (specifiedId, specifiedCodeName) {
        // ReSharper restore InconsistentNaming
        return {
            id: specifiedId,
            codeName: specifiedCodeName
        };
    },

    // Operation entity
    // ReSharper disable InconsistentNaming
    Operation = function (specifiedId, specifiedCodeName) {
        // ReSharper restore InconsistentNaming
        return {
            id: specifiedId,
            codeName: specifiedCodeName
        };
    },

    // Operations WorkPlace entity
    // ReSharper disable InconsistentNaming
    OperationsWorkPlace = function (specifiedId, specifiedCode, specifiedOperationId) {
        // ReSharper restore InconsistentNaming
        return {
            id: specifiedId,
            code: specifiedCode,
            operationId: specifiedOperationId
        };
    },

    // Hire Group Detail entity
    // ReSharper disable InconsistentNaming
    HireGroupDetail = function (specifiedId, specifiedCode, specifiedCategory, specifiedMake, specifiedModel, specifiedModelYear, specifiedHireGroupId) {
        // ReSharper restore InconsistentNaming
        return {
            id: specifiedId,
            code: specifiedCode,
            vehicleCategory: specifiedCategory,
            vehicleMake: specifiedMake,
            vehicleModel: specifiedModel,
            vehicleModelYear: specifiedModelYear,
            hireGroupId: specifiedHireGroupId,
            hireGroup: specifiedCode + ' | ' + specifiedCategory + ' | ' + specifiedMake + ' | ' + specifiedModel + ' | ' + specifiedModelYear
        };
    },

    // Rental Agreement entity
    // ReSharper disable InconsistentNaming
    RentalAgreement = function (specifiedId, specifiedStartDate, specifiedEndDate, specifiedPaymentTermId, specifiedOperationId, specifiedOpenLocation,
        specifiedCloseLocation, specifiedBusinessPartner, callbacks) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // RA Hire Groups
            rentalAgreementHireGroups = ko.observableArray([]),
            // RA Service Items
            rentalAgreementServiceItems = ko.observableArray([]),
            // RA Drivers
            rentalAgreementDrivers = ko.observableArray([]),
            // RA Additional Charge
            rentalAgreementAdditionalCharges = ko.observableArray([]),
            // Business Partner
            businessPartner = ko.observable(BusinessPartner.Create(specifiedBusinessPartner || {}, callbacks)),
            // Billing
            billing = ko.observable(Billing.Create({})),
            // Start Date Time
            internalStartDateTime = ko.observable(specifiedStartDate || moment().toDate()),
            // End Date Time
            internalEndDateTime = ko.observable(specifiedEndDate || moment().add('days', 1).toDate()),
            // day
            internalDays = ko.observable(1),
            // hour
            internalHours = ko.observable(),
            // minutes
            internalMinutes = ko.observable(),
            // Start Date
            start = ko.computed({
                read: function () {
                    return internalStartDateTime();
                },
                write: function (value) {
                    if (value === internalStartDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalStartDateTime(undefined);
                    } else {
                        internalStartDateTime(value);

                        var delta = moment.duration(end() - internalStartDateTime());

                        internalDays(!isNaN(delta.asDays()) ? Number(delta.asDays()).toFixed(0) : undefined);
                        internalHours(!isNaN(delta.asHours()) ? Number(delta.hours()).toFixed(0) : undefined);
                        internalMinutes(!isNaN(delta.asMinutes()) ? Number(delta.minutes()).toFixed(0) : undefined);
                        if (callbacks && callbacks.OnRentalDurationChange) {
                            callbacks.OnRentalDurationChange();
                        }
                    }
                }
            }),
            // End Date
            end = ko.computed({
                read: function () {
                    return internalEndDateTime();
                },
                write: function (value) {
                    if (value === internalEndDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalEndDateTime(undefined);
                    } else {
                        internalEndDateTime(value);
                        var delta = moment.duration(internalEndDateTime() - start());

                        internalDays(!isNaN(delta.asDays()) ? Number(delta.asDays()).toFixed(0) : undefined);
                        internalHours(!isNaN(delta.asHours()) ? Number(delta.hours()).toFixed(0) : undefined);
                        internalMinutes(!isNaN(delta.asMinutes()) ? Number(delta.minutes()).toFixed(0) : undefined);
                        if (callbacks && callbacks.OnRentalDurationChange) {
                            callbacks.OnRentalDurationChange();
                        }
                    }
                }
            }),
            // Days
            days = ko.computed({
                read: function () {
                    return internalDays();
                },
                write: function (value) {
                    if (internalDays() === value) {
                        return;
                    }
                    if (!value) {
                        return;
                    }
                    else {
                        internalDays(value);
                        end(new Date(start().getFullYear(), start().getMonth(), start().getDate() + parseInt(value), start().getHours() + parseInt(hours() ? hours() : 0),
                            start().getMinutes() + parseInt(minutes() ? minutes() : 0)));
                    }
                }
            }),
            // Hours
            hours = ko.computed({
                read: function () {
                    return internalHours();
                },
                write: function (value) {
                    if (internalHours() === value) {
                        return;
                    }
                    if (!value) {
                        return;
                    }
                    else {
                        internalHours(value);
                        end(new Date(start().getFullYear(), start().getMonth(), start().getDate() + parseInt(days() ? days() : 0), start().getHours() + parseInt(value),
                            start().getMinutes() + parseInt(minutes() ? minutes() : 0)));
                    }
                }
            }),
            // Hours
            minutes = ko.computed({
                read: function () {
                    return internalMinutes();
                },
                write: function (value) {
                    if (internalMinutes() === value) {
                        return;
                    }
                    if (!value) {
                        return;
                    }
                    else {
                        internalMinutes(value);
                        end(new Date(start().getFullYear(), start().getMonth(), start().getDate() + parseInt(days() ? days() : 0),
                            start().getHours() + parseInt(hours() ? hours() : 0), start().getMinutes() + parseInt(value)));
                    }
                }
            }),
            // Payment Term
            paymentTermId = ko.observable(specifiedPaymentTermId || undefined),
            // Operation
            operationId = ko.observable(specifiedOperationId || undefined),
            // Open Location
            internalOpenLocation = ko.observable(specifiedOpenLocation || undefined),
            // Open Location
            openLocation = ko.computed({
                read: function () {
                    return internalOpenLocation();
                },
                write: function (value) {
                    if (!value || value === internalOpenLocation()) {
                        return;
                    }

                    internalOpenLocation(value);

                    if (callbacks && callbacks.OnOutLocationChange) {
                        callbacks.OnOutLocationChange();
                    }
                }
            }),
            // Close Location
            closeLocation = ko.observable(specifiedCloseLocation || undefined),
            // Remove Ra Service Item
            removeRaServiceItem = function (raServiceItem) {
                rentalAgreementServiceItems.remove(raServiceItem);
            },
            // Ra Chauffers
            raChauffers = ko.computed(function () {
                return rentalAgreementDrivers.filter(function (raDriver) {
                    return raDriver.isChauffer();
                });
            }),
            // Ra Drivers
            raDrivers = ko.computed(function () {
                return rentalAgreementDrivers.filter(function (raDriver) {
                    return !raDriver.isChauffer();
                });
            }),
            // Remove Ra Driver
            removeRaDriver = function (raDriver) {
                rentalAgreementDrivers.remove(raDriver);
            },
            // Remove Ra Additional Charge
            removeRaAdditionalCharge = function (raAdditionalCharge) {
                rentalAgreementAdditionalCharges.remove(raAdditionalCharge);
            },
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    RaMainId: id(),
                    PaymentTermId: paymentTermId(),
                    OpenLocation: openLocation(),
                    CloseLocation: closeLocation(),
                    StartDtTime: moment(start()).format(ist.utcFormat) + 'Z',
                    EndDtTime: moment(end()).format(ist.utcFormat) + 'Z',
                    OperationId: operationId(),
                    BusinessPartnerId: businessPartner().id(),
                    RecCreatedDt: moment().format(ist.utcFormat) + 'Z',
                    RaHireGroups: rentalAgreementHireGroups.map(function (raHireGroup) {
                        return raHireGroup.convertToServerData();
                    }),
                    BusinessPartner: businessPartner().convertToServerData(),
                    RaServiceItems: rentalAgreementServiceItems.map(function (raServiceItem) {
                        return raServiceItem.convertToServerData();
                    }),
                    RaDrivers: rentalAgreementDrivers.map(function (raDriver) {
                        return raDriver.convertToServerData();
                    }),
                    RaAdditionalCharges: rentalAgreementAdditionalCharges.map(function (raAdditionalCharge) {
                        return raAdditionalCharge.convertToServerData();
                    })
                };
            };

        return {
            id: id,
            paymentTermId: paymentTermId,
            operationId: operationId,
            openLocation: openLocation,
            closeLocation: closeLocation,
            start: start,
            end: end,
            days: days,
            hours: hours,
            minutes: minutes,
            rentalAgreementHireGroups: rentalAgreementHireGroups,
            businessPartner: businessPartner,
            billing: billing,
            rentalAgreementServiceItems: rentalAgreementServiceItems,
            removeRaServiceItem: removeRaServiceItem,
            rentalAgreementDrivers: rentalAgreementDrivers,
            rentalAgreementAdditionalCharges: rentalAgreementAdditionalCharges,
            raChauffers: raChauffers,
            raDrivers: raDrivers,
            removeRaDriver: removeRaDriver,
            removeRaAdditionalCharge: removeRaAdditionalCharge,
            convertToServerData: convertToServerData
        };
    },

    // Vehicle Movement Enum
    vehicleMovementEnum = {
        outMovement: true,
        inMovement: false
    },

    // Rental Agreement Hire Group entity
    // ReSharper disable InconsistentNaming
    RentalAgreementHireGroup = function (specifiedId, specifiedHireGroupDetailId, specifiedVehicleId, specifiedRentalAgreementId, specifiedVehicle,
        specifiedVehicleMovements, specifiedRaHireGroupInsurances, specifiedAllocationStatusKey, specifiedAllocationStatusId) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // Hire Group Detail Id
            hireGroupDetailId = ko.observable(specifiedHireGroupDetailId),
            // Vehicle Id
            vehicleId = ko.observable(specifiedVehicleId),
            // Rental Agreement Id
            rentalAgreementId = ko.observable(specifiedRentalAgreementId),
            // Vehicle
            vehicle = ko.observable(specifiedVehicle || {}),
            // Ra HireGroup Insurances
            raHireGroupInsurances = ko.observableArray(specifiedRaHireGroupInsurances ? _.map(specifiedRaHireGroupInsurances, function(raHireGroupInsurance) {
                return RentalAgreementHireGroupInsurance.Create(raHireGroupInsurance);
            }) : []),
            // Vehicle Movements
            vehicleMovements = ko.observableArray(specifiedVehicleMovements ? _.map(specifiedVehicleMovements, function (vehicleMovement) {
                return VehicleMovement.Create(vehicleMovement);
            }) : []),
            // Vehicle Movement Out
            vehicleMovementOut = ko.computed(function() {
                var outMovement = vehicleMovements.find(function(vehicleMovement) {
                    return vehicleMovement.status() === vehicleMovementEnum.outMovement;
                });
                return outMovement || VehicleMovement.Create({});
            }),
            // Vehicle Movement In
            vehicleMovementIn = ko.computed(function () {
                var inMovement = vehicleMovements.find(function (vehicleMovement) {
                    return vehicleMovement.status() === vehicleMovementEnum.inMovement;
                });
                return inMovement || VehicleMovement.Create({});
            }),
            // Allocation Status Key
            allocationStatusKey = ko.observable(specifiedAllocationStatusKey),
            // Allocation Status Id
            allocationStatusId = ko.observable(specifiedAllocationStatusId),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    RaHireGroupId: id(),
                    HireGroupDetailId: hireGroupDetailId(),
                    VehicleId: vehicleId(),
                    RaMainId: rentalAgreementId(),
                    AllocationStatusKey: allocationStatusKey(),
                    AllocationStatusId: allocationStatusId(),
                    RaHireGroupInsurances: raHireGroupInsurances.map(function (raHireGroupInsurance) {
                        if (raHireGroupInsurance.isSelected()) {
                            return raHireGroupInsurance.convertToServerData();
                        }
                        return null;
                    }),
                    VehicleMovements: vehicleMovements.map(function (vehicleMovement) {
                        return vehicleMovement.convertToServerData();
                    })
                };
            };

        return {
            id: id,
            hireGroupDetailId: hireGroupDetailId,
            vehicleId: vehicleId,
            rentalAgreementId: rentalAgreementId,
            vehicle: vehicle,
            vehicleMovements: vehicleMovements,
            vehicleMovementOut: vehicleMovementOut,
            vehicleMovementIn: vehicleMovementIn,
            raHireGroupInsurances: raHireGroupInsurances,
            allocationStatusKey: allocationStatusKey,
            allocationStatusId: allocationStatusId,
            convertToServerData: convertToServerData
        };
    },

    // Phone Type entity
    // ReSharper disable InconsistentNaming
    PhoneType = function (specifiedId, specifiedKey) {
        // ReSharper restore InconsistentNaming

        return {
            id: specifiedId,
            key: specifiedKey
        };
    },

    // Phone entity
    // ReSharper disable InconsistentNaming
    Phone = function (specifiedId, specifiedIsDefault, specifiedBusinessPartnerId, specifiedType, specifiedPhoneNo) {
        // ReSharper restore InconsistentNaming
        var
            // Unique Id
            id = ko.observable(specifiedId || 0),
            // Is Default 
            isDefault = ko.observable(specifiedIsDefault || undefined),
            // Business Partner Id
            businessPartnerId = ko.observable(specifiedBusinessPartnerId || 0),
            // Phone Type
            type = ko.observable(specifiedType || undefined),
            // Phone No
            internalPhoneNo = ko.observable(specifiedPhoneNo || undefined),
            // Phone Number
            phoneNo = ko.computed({
                read: function () {
                    return internalPhoneNo();
                },
                write: function (value) {
                    if (internalPhoneNo() === value) {
                        return;
                    }

                    internalPhoneNo(value);
                }
            });

        return {
            id: id,
            isDefault: isDefault,
            businessPartnerId: businessPartnerId,
            type: type,
            phoneNo: phoneNo
        };
    },

    // Business Partner Company entity
    // ReSharper disable InconsistentNaming
    BusinessPartnerCompany = function (specifiedId, specifiedName, specifiedCode) {
        // ReSharper restore InconsistentNaming
        var
            // Business Partner key
            id = ko.observable(specifiedId || 0),
            // name
            name = ko.observable(specifiedName || undefined),
            // Code
            code = ko.observable(specifiedCode || undefined),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    BusinessPartnerId: id(),
                    BusinessPartnerCompanyCode: code(),
                    BusinessPartnerCompanyName: name()
                };
            };

        return {
            id: id,
            code: code,
            name: name,
            convertToServerData: convertToServerData
        };
    },

    // Business Partner Individual entity
    // ReSharper disable InconsistentNaming
    BusinessPartnerIndividual = function (specifiedId, specifiedFirstName, specifiedLastName, specifiedDOB, specifiedNicNumber, specifiedNicExpiry, specifiedPassportNo,
    specifiedPassportExpiry, specifiedLicenseNo, specifiedLicenseExpiry, callbacks, businessPartner) {
        // ReSharper restore InconsistentNaming
        var
            // Business Partner key
            id = ko.observable(specifiedId || 0),
            // First Name
            firstName = ko.observable(specifiedFirstName || undefined),
            // Last Name
            lastName = ko.observable(specifiedLastName || undefined),
            // Date of Birth
            dateOfBirth = ko.observable(specifiedDOB ? moment(specifiedDOB).toDate() : undefined),
            // Nic Expiry
            nicExpiry = ko.observable(specifiedNicExpiry ? moment(specifiedNicExpiry).toDate() : undefined),
            // Passport Expiry
            passportExpiry = ko.observable(specifiedPassportExpiry ? moment(specifiedPassportExpiry).toDate() : undefined),
            // License Expiry
            licenseExpiry = ko.observable(specifiedLicenseExpiry ? moment(specifiedLicenseExpiry).toDate() : undefined),
            // Nic Number - Private
            internalNicNo = ko.observable(specifiedNicNumber || undefined),
            // Nic Number
            nicNo = ko.computed({
                read: function () {
                    return internalNicNo();
                },
                write: function (value) {
                    if (!value || internalNicNo() === value) {
                        return;
                    }

                    internalNicNo(value);
                    if (callbacks && callbacks.OnNicChanged && typeof callbacks.OnNicChanged === "function" && businessPartner.isIndividual()) {
                        callbacks.OnNicChanged(value);
                    }
                }
            }),
            // Passport Number
            internalPassportNo = ko.observable(specifiedPassportNo || undefined),
            // Passport Number
            passportNo = ko.computed({
                read: function () {
                    return internalPassportNo();
                },
                write: function (value) {
                    if (!value || internalPassportNo() === value) {
                        return;
                    }

                    internalPassportNo(value);
                    if (callbacks && callbacks.OnPassportChanged && typeof callbacks.OnPassportChanged === "function" && businessPartner.isIndividual()) {
                        callbacks.OnPassportChanged(value);
                    }
                }
            }),
            // License Number
            internalLicenseNo = ko.observable(specifiedLicenseNo || undefined),
            // License Number
            licenseNo = ko.computed({
                read: function () {
                    return internalLicenseNo();
                },
                write: function (value) {
                    if (!value || internalLicenseNo() === value) {
                        return;
                    }

                    internalLicenseNo(value);
                    if (callbacks && callbacks.OnLicenseChanged && typeof callbacks.OnLicenseChanged === "function" && businessPartner.isIndividual()) {
                        callbacks.OnLicenseChanged(value);
                    }
                }
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    BusinessPartnerId: id(),
                    FirstName: firstName(),
                    LastName: lastName(),
                    DateOfBirth: moment(dateOfBirth()).format(ist.utcFormat) + 'Z',
                    NicExpiryDate: moment(nicExpiry()).format(ist.utcFormat) + 'Z',
                    LicenseExpiryDate: moment(licenseExpiry()).format(ist.utcFormat) + 'Z',
                    PassportExpiryDate: moment(passportExpiry()).format(ist.utcFormat) + 'Z',
                    NicNumber: nicNo(),
                    LiscenseNumber: licenseNo(),
                    PassportNumber: passportNo()
                };
            };

        return {
            id: id,
            firstName: firstName,
            lastName: lastName,
            dateOfBirth: dateOfBirth,
            nicExpiry: nicExpiry,
            passportExpiry: passportExpiry,
            licenseExpiry: licenseExpiry,
            nicNo: nicNo,
            passportNo: passportNo,
            licenseNo: licenseNo,
            convertToServerData: convertToServerData
        };
    },

    // Business Partner entity
    // ReSharper disable InconsistentNaming
    BusinessPartner = function (specifiedId, specifiedIsIndividual, specifiedPaymentTerm, specifiedBusinessPartnerIndividual,
    specifiedCompany, specifiedEmail, callbacks) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // customer Number
            customerNo = ko.computed({
                read: function () {
                    return id();
                },
                write: function (value) {
                    if (!value || id() === value) {
                        return;
                    }

                    id(value);
                    if (callbacks && callbacks.OnCustomerNoChanged && typeof callbacks.OnCustomerNoChanged === "function") {
                        callbacks.OnCustomerNoChanged(value);
                    }
                }
            }),
            // Is Individual
            isIndividual = ko.observable(specifiedIsIndividual || true),
            // Email
            email = ko.observable(specifiedEmail || undefined),
            // Payment Term
            paymentTermId = ko.observable(specifiedPaymentTerm ? specifiedPaymentTerm.PaymentTermId : undefined),
            // Company
            businessPartnerCompany = ko.observable(BusinessPartnerCompany.Create(specifiedCompany || {})),
            // Reference to this
            self = {
                isIndividual: isIndividual
            },
            // Individual
            businessPartnerIndividual = ko.observable(BusinessPartnerIndividual.Create(specifiedBusinessPartnerIndividual || {}, callbacks, self)),
            // Phones
            phones = ko.observableArray([]),
            // Home Phone
            internalHomePhone = ko.observable(),
            // Home Phone
            homePhone = ko.computed({
                read: function () {
                    return internalHomePhone();
                },
                write: function (value) {
                    if (!value || internalHomePhone() === value) {
                        return;
                    }

                    internalHomePhone(value);
                    if (callbacks && callbacks.OnPhoneChanged && typeof callbacks.OnPhoneChanged === "function") {
                        callbacks.OnPhoneChanged(value, phoneTypes.HomePhone);
                    }
                }
            }),
            // Mobile Phone
            internalMobile = ko.observable(),
            // Mobile Phone
            mobile = ko.computed({
                read: function () {
                    return internalMobile();
                },
                write: function (value) {
                    if (!value || internalMobile() === value) {
                        return;
                    }

                    internalMobile(value);
                    if (callbacks && callbacks.OnPhoneChanged && typeof callbacks.OnPhoneChanged === "function") {
                        callbacks.OnPhoneChanged(value, phoneTypes.CellularPone);
                    }
                }
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    BusinessPartnerId: id(),
                    IsIndividual: isIndividual(),
                    PaymentTermId: paymentTermId(),
                    BusinessPartnerEmailAddress: email(),
                    BusinessPartnerIndividual: businessPartnerIndividual().convertToServerData(),
                    BusinessPartnerCompany: businessPartnerCompany().convertToServerData()
                };
            };

        return {
            id: id,
            customerNo: customerNo,
            isIndividual: isIndividual,
            paymentTermId: paymentTermId,
            email: email,
            businessPartnerCompany: businessPartnerCompany,
            businessPartnerIndividual: businessPartnerIndividual,
            phones: phones,
            self: self,
            homePhone: homePhone,
            mobile: mobile,
            internalHomePhone: internalHomePhone,
            internalMobile: internalMobile,
            convertToServerData: convertToServerData
        };
    },

    // Billing entity
    // ReSharper disable InconsistentNaming
    Billing = function (specifiedVehicleCharge, specifiedStandardDiscount, specifiedSeasonalDiscount, specifiedVoucherDiscount, specifiedSpecialDiscount,
        specifiedExcessMileage, specifiedServiceCharge, specifiedInsuranceCharge, specifiedDriverCharge, specifiedAdditionalCharge, specifiedAmountPaid,
        specifiedNetBill, specifiedBalance, specifiedTotalCharges) {
        // ReSharper restore InconsistentNaming
        var
            // Vehicle Charge
            vehicleCharge = ko.observable(specifiedVehicleCharge || 0),
            // Standard Discount
            standardDiscount = ko.observable(specifiedSeasonalDiscount || 0),
            // Seasonal Discount
            seasonalDiscount = ko.observable(specifiedSeasonalDiscount || 0),
            // Voucher Discount
            voucherDiscount = ko.observable(specifiedVoucherDiscount || 0),
            // Special Discount
            specialDiscount = ko.observable(specifiedSpecialDiscount || 0),
            // Excess Mileage
            excessMileage = ko.observable(specifiedExcessMileage || 0),
            // Service Charge
            serviceCharge = ko.observable(specifiedServiceCharge || 0),
            // Insurance Charge
            insuranceCharge = ko.observable(specifiedInsuranceCharge || 0),
            // Driver Charge
            driverCharge = ko.observable(specifiedDriverCharge || 0),
            // Additional Charge
            additionalCharge = ko.observable(specifiedAdditionalCharge || 0),
            // Net Billing
            netBilling = ko.observable(specifiedNetBill || 0),
            // Total Charges
            totalCharges = ko.observable(specifiedTotalCharges || 0),
            // Amount Paid
            amountPaid = ko.observable(specifiedAmountPaid || 0),
            // Balance
            balance = ko.observable(specifiedBalance || 0);

        return {
            vehicleCharge: vehicleCharge,
            standardDiscount: standardDiscount,
            seasonalDiscount: seasonalDiscount,
            voucherDiscount: voucherDiscount,
            specialDiscount: specialDiscount,
            excessMileage: excessMileage,
            serviceCharge: serviceCharge,
            insuranceCharge: insuranceCharge,
            driverCharge: driverCharge,
            additionalCharge: additionalCharge,
            netBilling: netBilling,
            totalCharges: totalCharges,
            amountPaid: amountPaid,
            balance: balance
        };
    },

    // Chauffer Entity
    // ReSharper disable InconsistentNaming
    Chauffer = function (specifiedId, specifiedCode, specifiedName, specifiedDesigGradeName, specifiedDesigGradeId, specifiedLicenseNo, specifiedLicenseExpDt) {
        // ReSharper restore InconsistentNaming
        var
            // Is Selected
            isSelected = ko.observable(),
            // Start Date Time
            internalStartDateTime = ko.observable(),
            // End Date Time
            internalEndDateTime = ko.observable(),
            // Start Date
            start = ko.computed({
                read: function () {
                    return internalStartDateTime();
                },
                write: function (value) {
                    if (value === internalStartDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalStartDateTime(undefined);
                    } else {
                        internalStartDateTime(value);
                    }
                }
            }),
            // End Date
            end = ko.computed({
                read: function () {
                    return internalEndDateTime();
                },
                write: function (value) {
                    if (value === internalEndDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalEndDateTime(undefined);
                    } else {
                        internalEndDateTime(value);
                    }
                }
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    ChaufferId: specifiedId,
                    DriverName: specifiedName,
                    DesigGradeId: specifiedDesigGradeId,
                    LicenseNo: specifiedLicenseNo,
                    LicenseExpDt: moment(specifiedLicenseExpDt).toDate()
                }
            };

        return {
            id: specifiedId,
            code: specifiedCode,
            name: specifiedName,
            desigGrade: specifiedDesigGradeName,
            desigGradeId: specifiedDesigGradeId,
            licenseNo: specifiedLicenseNo,
            licenseDt: moment(specifiedLicenseExpDt).toDate(),
            isSelected: isSelected,
            start: start,
            end: end,
            convertToServerData: convertToServerData
        };
    },

    // Service Item Entity
    // ReSharper disable InconsistentNaming
    ServiceItem = function (specifiedId, specifiedCode, specifiedName, specifiedServiceTypeName, specifiedServiceTypeCode) {
        // ReSharper restore InconsistentNaming
        // Is Selected
        var isSelected = ko.observable(false),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    ServiceItemId: specifiedId,
                    ServiceItemCode: specifiedCode,
                    ServiceItemName: specifiedName,
                    ServiceTypeCode: specifiedServiceTypeCode,
                    ServiceTypeName: specifiedServiceTypeName
                }
            };

        return {
            id: specifiedId,
            code: specifiedCode,
            name: specifiedName,
            serviceTypeName: specifiedServiceTypeName,
            serviceTypeCodeName: specifiedServiceTypeCode + '-' + specifiedServiceTypeName,
            serviceTypeCode: specifiedServiceTypeCode,
            isSelected: isSelected,
            convertToServerData: convertToServerData
        };
    },

    // Rental Agreement Service Item entity
    // ReSharper disable InconsistentNaming
    RentalAgreementServiceItem = function (specifiedId, specifiedServiceItemId, specifiedServiceItemCode, specifiedServiceItemName, specifiedServiceTypeCode,
        specifiedServiceTypeName, specifiedRentalAgreementId, specifiedQuantity, specifiedStartDtTime, specifiedEndDtTime, specifiedServiceRate,
        specifiedServiceCharge) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // Service Item Id
            serviceItemId = ko.observable(specifiedServiceItemId),
            // Service Item Code
            serviceItemCode = ko.observable(specifiedServiceItemCode),
            // Service Item Name
            serviceItemName = ko.observable(specifiedServiceItemName),
            // Service Type Code
            serviceTypeCode = ko.observable(specifiedServiceTypeCode),
            // Service Type Name
            serviceTypeName = ko.observable(specifiedServiceTypeName),
            // Rental Agreement Id
            rentalAgreementId = ko.observable(specifiedRentalAgreementId),
            // Quantity
            quantity = ko.observable(specifiedQuantity || 1),
            // Service Rate
            serviceRate = ko.observable(specifiedServiceRate || 0),
            // Service Charge
            serviceCharge = ko.observable(specifiedServiceCharge || 0),
            // Start Date Time
            internalStartDateTime = ko.observable(specifiedStartDtTime || moment().toDate()),
            // End Date Time
            internalEndDateTime = ko.observable(specifiedEndDtTime || moment().add('days', 1).toDate()),
            // Start Date
            start = ko.computed({
                read: function () {
                    return internalStartDateTime();
                },
                write: function (value) {
                    if (value === internalStartDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalStartDateTime(undefined);
                    } else {
                        internalStartDateTime(value);
                    }
                }
            }),
            // End Date
            end = ko.computed({
                read: function () {
                    return internalEndDateTime();
                },
                write: function (value) {
                    if (value === internalEndDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalEndDateTime(undefined);
                    } else {
                        internalEndDateTime(value);
                    }
                }
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    RaServiceItemId: id(),
                    ServiceItemId: serviceItemId(),
                    ServiceItemCode: serviceItemCode(),
                    ServiceItemName: serviceItemName(),
                    ServiceTypeCode: serviceTypeCode(),
                    ServiceTypeName: serviceTypeName(),
                    RaMainId: rentalAgreementId(),
                    StartDtTime: moment(start()).format(ist.utcFormat) + 'Z',
                    EndDtTime: moment(end()).format(ist.utcFormat) + 'Z',
                    Quantity: quantity(),
                    ServiceRate: serviceRate(),
                    ServiceCharge: serviceCharge()
                };
            };

        return {
            id: id,
            serviceItemId: serviceItemId,
            serviceItemName: serviceItemName,
            serviceItemCode: serviceItemCode,
            serviceTypeCode: serviceTypeCode,
            serviceTypeName: serviceTypeName,
            serviceTypeCodeName: specifiedServiceTypeCode + '-' + specifiedServiceTypeName,
            serviceItemCodeName: specifiedServiceItemCode + '-' + specifiedServiceItemName,
            rentalAgreementId: rentalAgreementId,
            quantity: quantity,
            start: start,
            end: end,
            serviceRate: serviceRate,
            serviceCharge: serviceCharge,
            convertToServerData: convertToServerData
        };
    },

    // Rental Agreement Driver Item entity
    // ReSharper disable InconsistentNaming
    RentalAgreementDriver = function (specifiedId, specifiedChaufferId, specifiedDesigGradeId, specifiedStartDtTime, specifiedEndDtTime, specifiedLicenseExpDt,
        specifiedLicenseNo, specifiedDriverName, specifiedIsChauffer, specifiedTariffType, specifiedRate, specifiedTotalCharge, specifiedRentalAgreementId) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // Chauffer Id
            chaufferId = ko.observable(specifiedChaufferId),
            // Desig Grade
            desigGradeId = ko.observable(specifiedDesigGradeId),
            // Rental Agreement Id
            rentalAgreementId = ko.observable(specifiedRentalAgreementId),
            // Start Date Time
            internalStartDateTime = ko.observable(specifiedStartDtTime || moment().toDate()),
            // End Date Time
            internalEndDateTime = ko.observable(specifiedEndDtTime || moment().add('days', 1).toDate()),
            // Start Date
            start = ko.computed({
                read: function () {
                    return internalStartDateTime();
                },
                write: function (value) {
                    if (value === internalStartDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalStartDateTime(undefined);
                    } else {
                        internalStartDateTime(value);
                    }
                }
            }),
            // End Date
            end = ko.computed({
                read: function () {
                    return internalEndDateTime();
                },
                write: function (value) {
                    if (value === internalEndDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalEndDateTime(undefined);
                    } else {
                        internalEndDateTime(value);
                    }
                }
            }),
            // License Exp Dt
            internalLicenseExpDateTime = ko.observable(specifiedLicenseExpDt || moment().toDate()),
            // License Exp Dt
            licenseExpDt = ko.computed({
                read: function () {
                    return internalLicenseExpDateTime();
                },
                write: function (value) {
                    if (value === internalLicenseExpDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalLicenseExpDateTime(undefined);
                    } else {
                        internalLicenseExpDateTime(value);
                    }
                }
            }),
            // License No
            licenseNo = ko.observable(specifiedLicenseNo),
            // Driver Name
            driverName = ko.observable(specifiedDriverName),
            // Is Chauffer
            isChauffer = ko.observable(specifiedIsChauffer),
            // Tariff Type
            tariffType = ko.observable(specifiedTariffType),
            // Rate
            rate = ko.observable(specifiedRate),
            // Total Charge
            totalCharge = ko.observable(specifiedTotalCharge),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    RaDriverId: id(),
                    ChaufferId: chaufferId(),
                    DesigGradeId: desigGradeId(),
                    LicenseNo: licenseNo(),
                    LicenseExpDt: moment(licenseExpDt()).format(ist.utcFormat) + 'Z',
                    Rate: rate(),
                    TotalCharge: totalCharge(),
                    DriverName: driverName(),
                    IsChauffer: isChauffer(),
                    TariffType: tariffType(),
                    RaMainId: rentalAgreementId(),
                    StartDtTime: moment(start()).format(ist.utcFormat) + 'Z',
                    EndDtTime: moment(end()).format(ist.utcFormat) + 'Z'
                };
            };

        return {
            id: id,
            chaufferId: chaufferId,
            desigGradeId: desigGradeId,
            rentalAgreementId: rentalAgreementId,
            start: start,
            end: end,
            licenseNo: licenseNo,
            licenseExpDt: licenseExpDt,
            rate: rate,
            totalCharge: totalCharge,
            driverName: driverName,
            isChauffer: isChauffer,
            tariffType: tariffType,
            convertToServerData: convertToServerData
        };
    },

    // Insurance Rate Entity
    // ReSharper disable InconsistentNaming
    InsuranceType = function (specifiedId, specifiedTypeCodeName) {
        // ReSharper restore InconsistentNaming
        return {
            id: specifiedId,
            codeName: specifiedTypeCodeName
        };
    },

    // Allocation Status Entity
    // ReSharper disable InconsistentNaming
    AllocationStatus = function (specifiedId, specifiedTypeCodeName, specifiedKey) {
        // ReSharper restore InconsistentNaming

        return {
            id: specifiedId,
            codeName: specifiedTypeCodeName,
            key: specifiedKey
        };
    },

    // Vehicle Status Entity
    // ReSharper disable InconsistentNaming
    VehicleStatus = function (specifiedId, specifiedTypeCodeName) {
        // ReSharper restore InconsistentNaming

        return {
            id: specifiedId,
            codeName: specifiedTypeCodeName
        };
    },

    // Rental Agreement Hire Group Insurance entity
    // ReSharper disable InconsistentNaming
    RentalAgreementHireGroupInsurance = function (specifiedId, specifiedRaHireGroupId, specifiedInsuranceTypeId, specifiedInsuranceTypeCodeName,
        specifiedStartDtTime, specifiedEndDtTime, specifiedInsuranceRate, specifiedInsuranceCharge, specifiedTariffType) {
        // ReSharper restore InconsistentNaming
        var
            // Is Selected
            isSelected = ko.observable(false),
            // unique key
            id = ko.observable(specifiedId || 0),
            // Ra Hire Group Id
            raHireGroupId = ko.observable(specifiedRaHireGroupId),
            // InsuranceType Id
            insuranceTypeId = ko.observable(specifiedInsuranceTypeId),
            // Insurance Type Code Name
            insuranceTypeCodeName = ko.observable(specifiedInsuranceTypeCodeName),
            // insurance Rate
            insuranceRate = ko.observable(specifiedInsuranceRate || 0),
            // Insurance Charge
            insuranceCharge = ko.observable(specifiedInsuranceCharge || 0),
            // Tariff Type
            tariffType = ko.observable(specifiedTariffType),
            // Start Date Time
            internalStartDateTime = ko.observable(specifiedStartDtTime || moment().toDate()),
            // End Date Time
            internalEndDateTime = ko.observable(specifiedEndDtTime || moment().add('days', 1).toDate()),
            // Start Date
            start = ko.computed({
                read: function () {
                    return internalStartDateTime();
                },
                write: function (value) {
                    if (value === internalStartDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalStartDateTime(undefined);
                    } else {
                        internalStartDateTime(value);
                    }
                }
            }),
            // End Date
            end = ko.computed({
                read: function () {
                    return internalEndDateTime();
                },
                write: function (value) {
                    if (value === internalEndDateTime()) {
                        return;
                    }
                    if (!value) {
                        internalEndDateTime(undefined);
                    } else {
                        internalEndDateTime(value);
                    }
                }
            }),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    RaHireGroupInsuranceId: id(),
                    RaHireGroupId: raHireGroupId(),
                    InsuranceTypeId: insuranceTypeId(),
                    StartDtTime: moment(start()).format(ist.utcFormat) + 'Z',
                    EndDtTime: moment(end()).format(ist.utcFormat) + 'Z',
                    TariffType: tariffType(),
                    InsuranceRate: insuranceRate(),
                    InsuranceCharge: insuranceCharge()
                };
            };

        return {
            id: id,
            raHireGroupId: raHireGroupId,
            insuranceTypeId: insuranceTypeId,
            insuranceTypeCodeName: insuranceTypeCodeName,
            tariffType: tariffType,
            start: start,
            end: end,
            insuranceRate: insuranceRate,
            insuranceCharge: insuranceCharge,
            isSelected: isSelected,
            convertToServerData: convertToServerData
        };
    },

    // Additional Charge Entity
    // ReSharper disable InconsistentNaming
    AdditionalCharge = function (specifiedId, specifiedAdditionalChargeTypeId, specifiedAdditionalChargeTypeCodeName, specifiedRate,
        specifiedHireGroupDetailCodeName, specifiedHireGroupDetailId) {

        var // Is Selected
            isSelected = ko.observable(false),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    AdditionalChargeId: specifiedId,
                    AdditionalChargeTypeId: specifiedAdditionalChargeTypeId,
                    AdditionalChargeTypeCodeName: specifiedAdditionalChargeTypeCodeName,
                    AdditionalChargeRate: specifiedRate,
                    HireGroupDetailId: specifiedHireGroupDetailId,
                    HireGroupDetailCodeName: specifiedHireGroupDetailCodeName
                }
            };

        return {
            id: specifiedId,
            additionalChargeTypeId: specifiedAdditionalChargeTypeId,
            additionalChargeTypeCodeName: specifiedAdditionalChargeTypeCodeName,
            rate: specifiedRate,
            hireGroupDetailCodeName: specifiedHireGroupDetailCodeName,
            hireGroupDetailId: specifiedHireGroupDetailId,
            isSelected: isSelected,
            convertToServerData: convertToServerData
        };
    },

    // Rental Agreement Additional Charge entity
    // ReSharper disable InconsistentNaming
    RentalAgreementAdditionalCharge = function (specifiedId, specifiedRaMainId, specifiedAdditionalChargeTypeId, specifiedAdditionalChargeTypeCodeName,
        specifiedAdditionalChargeRate, specifiedPlateNumber, specifiedQuantity, specifiedHireGroupDetailId, specifiedHireGroupDetailCodeName) {
        // ReSharper restore InconsistentNaming
        var
            // unique key
            id = ko.observable(specifiedId || 0),
            // Ra Main Id
            raMainId = ko.observable(specifiedRaMainId),
            // Additional Charge Type Id
            additionalChargeTypeId = ko.observable(specifiedAdditionalChargeTypeId),
            // Additional Charge Rate
            additionalChargeRate = ko.observable(specifiedAdditionalChargeRate || 0),
            // Plate Number
            plateNumber = ko.observable(specifiedPlateNumber),
            // Quantity
            quantity = ko.observable(specifiedQuantity || 1),
            // Hire Group Detail Id
            hireGroupDetailId = ko.observable(specifiedHireGroupDetailId),
            // Convert To Server Data
            convertToServerData = function () {
                return {
                    RaAdditionalChargeId: id(),
                    RaMainId: raMainId(),
                    AdditionalChargeTypeId: additionalChargeTypeId(),
                    AdditionalChargeRate: additionalChargeRate(),
                    Quantity: quantity(),
                    HireGroupDetailId: hireGroupDetailId(),
                    PlateNumber: plateNumber()
                };
            };

        return {
            id: id,
            raMainId: raMainId,
            additionalChargeTypeId: additionalChargeTypeId,
            additionalChargeRate: additionalChargeRate,
            additionalChargeTypeCodeName: specifiedAdditionalChargeTypeCodeName,
            quantity: quantity,
            plateNumber: plateNumber,
            hireGroupDetailId: hireGroupDetailId,
            hireGroupDetail: specifiedHireGroupDetailCodeName,
            convertToServerData: convertToServerData
        };
    };

    // Vehicle Factory
    Vehicle.Create = function (source) {
        return new Vehicle(source.VehicleId, source.VehicleName, source.VehicleCode, source.PlateNumber, source.CurrentOdometer, source.VehicleCategoryId,
        source.VehicleCategory ? source.VehicleCategory.VehicleCategoryCodeName : undefined, source.VehicleMakeId,
        source.VehicleMake ? source.VehicleMake.VehicleMakeCodeName : undefined, source.VehicleModelId,
        source.VehicleModel ? source.VehicleModel.VehicleModelCodeName : undefined, source.VehicleStatusId, source.VehicleStatusCodeName, source.ModelYear,
        source.ImageSource, source.FuelLevel, source.TankSize);
    };

    // Payment Term Factory
    PaymentTerm.Create = function (source) {
        return new PaymentTerm(source.PaymentTermId, source.PaymentTermCodeName);
    };

    // Operation Factory
    Operation.Create = function (source) {
        return new Operation(source.OperationId, source.OperationCodeName);
    };

    // Operations WorkPlace Factory
    OperationsWorkPlace.Create = function (source) {
        return new OperationsWorkPlace(source.OperationsWorkPlaceId, source.LocationCode, source.OperationId);
    };

    // HireGroup Detail Factory
    HireGroupDetail.Create = function (source) {
        return new HireGroupDetail(source.HireGroupDetailId, source.HireGroup, source.VehicleCategory, source.VehicleMake, source.VehicleModel, source.ModelYear,
            source.HireGroupId);
    };

    // Rental Agreement Hire Group Factory
    RentalAgreementHireGroup.Create = function (source) {
        return new RentalAgreementHireGroup(source.RentalAgreementHireGroupId, source.HireGroupDetailId, source.VehicleId,
            source.RaMainId, source.Vehicle, source.VehicleMovements, source.RaHireGroupInsurances, source.AllocationStatusKey, source.AllocationStatusId);
    };

    // Phone Type Enums
    var phoneTypes = {
        // ReSharper restore InconsistentNaming
        CellularPone: 1,
        HomePhone: 2,
        BusinessPhone: 3,
        AssistancePhone: 4,
        OtherPhone: 5,
        Fax: 6
    };

    // Phone Type Factory
    PhoneType.Create = function (source) {
        return new PhoneType(source.PhoneTypeId, source.PhoneTypeKey);
    };

    // Phone Factory
    Phone.Create = function (source, callbacks) {
        return new Phone(source.PhoneId, source.IsDefault, source.BusinessPartnerId, source.PhoneTypeId ?
            PhoneType.Create({ PhoneTypeId: source.PhoneTypeId, PhoneTypeKey: source.PhoneTypeKey }) : undefined, source.PhoneNo,
        callbacks);
    };

    // Business Partner Company Factory
    BusinessPartnerCompany.Create = function (source) {
        return new BusinessPartnerCompany(source.BusinessPartnerId, source.BusinessPartnerCompanyCode, source.BusinessPartnerCompanyName);
    };

    // Business Partner Individual Factory
    BusinessPartnerIndividual.Create = function (source, callbacks, businessPartner) {
        return new BusinessPartnerIndividual(source.BusinessPartnerId, source.FirstName, source.LastName, source.DateOfBirth, source.NicNumber, source.NicExpiryDate,
        source.PassportNumber, source.PassportExpiryDate, source.LiscenseNumber, source.LiscenseExpiryDate, callbacks, businessPartner);
    };

    // Business Partner Factory
    BusinessPartner.Create = function (source, callbacks) {
        var businessPartner = new BusinessPartner(source.BusinessPartnerId, source.IsIndividual, source.PaymentTerm,
            source.BusinessPartnerIndividual, source.BusinessPartnerCompany, source.BusinessPartnerEmailAddress, callbacks);

        // Add Phones
        if (!source.BusinessPartnerPhoneNumbers) {
            source.BusinessPartnerPhoneNumbers = [
                { IsDefault: true, PhoneTypeKey: phoneTypes.HomePhone },
                { IsDefault: true, PhoneTypeKey: phoneTypes.CellularPone }
            ];
        }

        _.each(source.BusinessPartnerPhoneNumbers, function (phone) {
            businessPartner.phones.push(Phone.Create(phone));
            if (phone.PhoneTypeKey === phoneTypes.HomePhone) {
                businessPartner.internalHomePhone(phone.PhoneNumber);
            }
            else {
                businessPartner.internalMobile(phone.PhoneNumber);
            }
        });

        return businessPartner;
    };

    // Rental Agreement Factory
    RentalAgreement.Create = function (source, callbacks) {
        return new RentalAgreement(source.RentalAgreementId, source.StartDateTime ? moment(source.StartDateTime).toDate() : undefined,
            source.EndDateTime ? moment(source.EndDateTime).toDate() : undefined, source.PaymentTermId, source.OperationId, source.OpenLocation, source.CloseLocation,
        source.BusinessPartner || {}, callbacks);
    };

    // Billing Factory
    Billing.Create = function (source) {
        return new Billing(source.TotalVehicleCharge, source.StandardDiscount, source.SeasonalDiscount, source.VoucherDiscount, source.SpecialDiscount,
            source.TotalExcessMileageCharge, source.TotalServiceCharge, source.TotalInsuranceCharge, source.TotalDriverCharge, source.TotalAdditionalCharge,
            source.AmountPaid, source.NetBillAfterDiscount, source.Balance, source.TotalOtherCharge);
    };

    // Service Item Factory
    ServiceItem.Create = function (source) {
        return new ServiceItem(source.ServiceItemId, source.ServiceItemCode, source.ServiceItemName, source.ServiceTypeName, source.ServiceTypeCode,
            source.ServiceTypeCodeName);
    };

    // Chauffer Factory
    Chauffer.Create = function (source) {
        return new Chauffer(source.ChaufferId, source.ChaufferCode, source.DesigGradeCodeName, source.DesigGradeId, source.LicenseNo,
            source.LicenseExpDt);
    };

    // Rental Agreement Service Item Factory
    RentalAgreementServiceItem.Create = function (source) {
        return new RentalAgreementServiceItem(source.RaServiceItemId, source.ServiceItemId, source.ServiceItemCode, source.ServiceItemName, source.ServiceTypeCode,
            source.ServiceTypeName, source.RaMainId, source.Quantity, source.StartDtTime, source.EndDtTime, source.ServiceRate, source.ServiceCharge);
    };

    // Rental Agreement Driver Factory
    RentalAgreementDriver.Create = function (source) {
        return new RentalAgreementDriver(source.RaDriverId, source.ChaufferId, source.DesigGradeId, source.StartDtTime, source.EndDtTime, source.LicenseExpDt,
            source.LicenseNo, source.DriverName, source.IsChauffer, source.TariffType, source.Rate, source.TotalCharge, source.RaMainId);
    };

    // Rental Agreement HireGroup Insurance Factory
    RentalAgreementHireGroupInsurance.Create = function (source) {
        return new RentalAgreementHireGroupInsurance(source.RaHireGroupInsuranceId, source.RaHireGroupId, source.InsuranceTypeId, source.InsuranceTypeCodeName,
            source.StartDtTime, source.EndDtTime, source.InsuranceRate, source.InsuranceCharg, source.TariffType);
    };

    // Insurance Type Factory
    InsuranceType.Create = function (source) {
        return new InsuranceType(source.InsuranceTypeId, source.InsuranceTypeCodeName);
    };

    // Additional Charge Factory
    AdditionalCharge.Create = function (source) {
        return new AdditionalCharge(source.AdditionalChargeId, source.AdditionalChargeTypeId, source.AdditionalChargeTypeCodeName, source.AdditionalChargeRate,
            source.HireGroupDetailCodeName);
    };

    // Ra Additional Charge Factory
    RentalAgreementAdditionalCharge.Create = function (source) {
        return new RentalAgreementAdditionalCharge(source.RaAdditionalChargeId, source.RaMainId, source.AdditionalChargeTypeId, source.AdditionalChargeTypeCodeName,
            source.AdditionalChargeRate, source.PlateNumber, source.Quantity, source.HireGroupDetailId, source.HireGroupDetailCodeName);
    };

    // Vehicle Movement Factory
    VehicleMovement.Create = function (source) {
        return new VehicleMovement(source.VehicleMovementId, source.RaHireGroupId, source.OperationsWorkPlaceId, source.VehicleStatusId, 
            source.Status, source.DtTime, source.Odometer, source.FuelLevel, source.VehicleCondition, source.VehicleConditionDescription);
    };

    // Allocation Status Factory
    AllocationStatus.Create = function (source) {
        return new AllocationStatus(source.AllocationStatusId, source.AllocationStatusCodeName, source.AllocationStatusKey);
    };

    // Vehicle Status Factory
    VehicleStatus.Create = function (source) {
        return new VehicleStatus(source.VehicleStatusId, source.VehicleStatusCodeName);
    };

    return {
        // Vehicle Constructor
        Vehicle: Vehicle,
        // Payment term Constructor
        PaymentTerm: PaymentTerm,
        // Operation Constructor
        Operation: Operation,
        // OperationsWorkPlace Constructor
        OperationsWorkPlace: OperationsWorkPlace,
        // HireGroupDetail Constructor
        HireGroupDetail: HireGroupDetail,
        // Rental Agreement Constructor
        RentalAgreement: RentalAgreement,
        // Rental Agreement HireGroup Constructor
        RentalAgreementHireGroup: RentalAgreementHireGroup,
        // Business Partner Constructor
        BusinessPartner: BusinessPartner,
        // Billing Constructor
        Billing: Billing,
        // Service Item Constructor
        ServiceItem: ServiceItem,
        // Chauffer Constructor
        Chauffer: Chauffer,
        // Ra Service Item Constructor
        RentalAgreementServiceItem: RentalAgreementServiceItem,
        // Ra Driver Constructor
        RentalAgreementDriver: RentalAgreementDriver,
        // Ra HireGroup Insurance Constructor
        RentalAgreementHireGroupInsurance: RentalAgreementHireGroupInsurance,
        // Insurance Type Constructor
        InsuranceType: InsuranceType,
        // Additional Charge Constructor
        AdditionalCharge: AdditionalCharge,
        // Ra Additional Charge Constructor
        RentalAgreementAdditionalCharge: RentalAgreementAdditionalCharge,
        // Vehicle Movement Constructor
        VehicleMovement: VehicleMovement,
        // Vehicle Movement Enum
        vehicleMovementEnum: vehicleMovementEnum,
        // Allocation Status Constructor
        AllocationStatus: AllocationStatus,
        // Vehicle Status Constructor
        VehicleStatus: VehicleStatus
    };
});