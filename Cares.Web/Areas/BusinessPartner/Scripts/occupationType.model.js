﻿define(["ko", "underscore", "underscore-ko"], function(ko) {
    
    //Occupation Type Detail
    var occupationTypeDetail = function (specifiedId, specifiedCode, specifiedName, specifieddescription) {
        var            
            id = ko.observable(specifiedId),
            code = ko.observable(specifiedCode).extend({ required: true }),
            name = ko.observable(specifiedName).extend({ required: true }),
            description = ko.observable(specifieddescription),
            errors = ko.validation.group({
                name: name,
                code: code,
            }),
            // Is Valid
            isValid = ko.computed(function() {
                return errors().length === 0;
            }),
            dirtyFlag = new ko.dirtyFlag({
                name: name,
                code: code,
            }),
            // Has Changes
            hasChanges = ko.computed(function() {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function() {
                dirtyFlag.reset();
            },
            // Convert to server
            convertToServerData = function () {
                return {
                    OccupationTypeId: id(),
                    OccupationTypeCode: code(),
                    OccupationTypeName: name(),
                    OccupationTypeDescription: description(),
                };
            };
        return {
            id: id,
            code: code,
            name: name,
            description: description,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            convertToServerData: convertToServerData,
            reset: reset
            
        };
    };
    // server to client mapper
    var occupationTypeServertoClinetMapper = function (source) {
        return occupationTypeDetail.Create(source);
    };
    
    //Occupation Type Factory
    occupationTypeDetail.Create = function (source) {
        return new occupationTypeDetail(source.OccupationTypeId, source.OccupationTypeCode, source.OccupationTypeName, source.OccupationTypeDescription);
    };

    //function to attain cancel button functionality 
    occupationTypeDetail.CreateFromClientModel = function (itemFromServer) {
        return new occupationTypeDetail(itemFromServer.id, itemFromServer.code, itemFromServer.name,
            itemFromServer.description);
    };
    return {
        OccupationTypeDetail: occupationTypeDetail,
        occupationTypeServertoClinetMapper: occupationTypeServertoClinetMapper,
    };
});