﻿/*
    Data service module with ajax calls to the server
*/
define("businessPartner/businessPartner.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {
                    
                    // Define request to get Business Partner base 
                    amplify.request.define('getBusinessPartnerBase', 'ajax', {
                        url: '/Api/BusinessPartnerBase',
                        dataType: 'json',
                        type: 'GET'
                    });

                    // Define request to get Business Partners
                    amplify.request.define('getBusinessPartners', 'ajax', {
                        url: '/Api/BusinessPartner',
                        dataType: 'json',
                        type: 'GET'
                    });

                    // Define request to save Business Partner
                    amplify.request.define('createBusinessPartner', 'ajax', {
                        url: '/Api/BusinessPartner',
                        dataType: 'json',
                        type: 'PUT'
                    });
                    
                    // Define request to update Business Partner
                    amplify.request.define('updateBusinessPartner', 'ajax', {
                        url: '/Api/BusinessPartner',
                        dataType: 'json',
                        type: 'POST'
                    });
                    
                    // Define request to delete Business Partner
                    amplify.request.define('deleteBusinessPartner', 'ajax', {
                        url: '/Api/BusinessPartner',
                        dataType: 'json',
                        type: 'DELETE'
                    });

                    isInitialized = true;
                }
            },
            
            // Get Business Partners
            getBusinessPartners = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getBusinessPartners',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            
            // Get Business Partner Base
            getBusinessPartnerBase = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getBusinessPartnerBase',
                    success: callbacks.success,
                    error: callbacks.error
                });
            },
            
            // Create Business Partner
            createBusinessPartner = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'createBusinessPartner',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
            
            // Update a Business Partner
            updateBusinessPartner = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'updateBusinessPartner',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
            
            // delete Business Partner
            deleteBusinessPartner = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'deleteBusinessPartner',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            };


        return {
            getBusinessPartners: getBusinessPartners,
            createBusinessPartner: createBusinessPartner,
            updateBusinessPartner: updateBusinessPartner,
            deleteBusinessPartner: deleteBusinessPartner,
            getBusinessPartnerBase: getBusinessPartnerBase  
        };
    })();

    return dataService;
});