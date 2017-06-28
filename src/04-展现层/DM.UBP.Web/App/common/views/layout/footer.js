(function () {
    appModule.controller('common.views.layout.footer', [
        '$rootScope', 'appSession',
        function ($scope, appSession) {
            var vm = this;

            $scope.$on('$includeContentLoaded', function () {
                Layout.initFooter(); // init footer
            });

            vm.getProductNameWithEdition = function() {
                //TODO:zipiii update AbpZeroTemplate to DM.UBP/UBP
                var productName = 'DM.UBP';
                if (appSession.tenant && appSession.tenant.editionDisplayName) {
                    productName = productName + ' ' + appSession.tenant.editionDisplayName;
                }

                return productName;
            }
        }
    ]);
})();