(function ($)
{
    var _iconListModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Mpa/Layout/IconList',
        scriptUrl: abp.appPath + 'Areas/Mpa/Views/Layout/_IconList.js',
        modalClass: 'IconListModal',
        modalContentCssClass: 'modal-content-iconlist',
    });

    $('#Iconic').click(function ()
    {
        _iconListModal.open(null, function (result)
        {
            $("#Iconic").attr("class", result);
            $("#Icon").val(result);
        });
    });


    app.modals.CreateOrEditModuleModal = function ()
    {
        var _moduleService = abp.services.app.module;

        var _modalManager;
        var _$moduleInformationForm = null;

        this.init = function (modalManager)
        {
            _modalManager = modalManager;

            _$moduleInformationForm = _modalManager.getModal().find('form[name=ModuleInformationsForm]');
            _$moduleInformationForm.validate();
        };

        this.save = function ()
        {
            if (!_$moduleInformationForm.valid())
            {
                return;
            }

            var module = _$moduleInformationForm.serializeFormToObject();

            _modalManager.setBusy(true);

            if (module.Id >= 0)
            {
                //修改模块
                _moduleService.updateModule(module)
                    .done(function ()
                    {
                        abp.notify.info(app.localize('SavedSuccessfully'));
                        _modalManager.close();
                        abp.event.trigger('app.createOrEditModuleModalSaved');
                    }).always(function ()
                    {
                        _modalManager.setBusy(false);
                    });
            }
            else
            {
                //新建模块
                _moduleService.createModule(module)
                    .done(function ()
                    {
                        abp.notify.info(app.localize('SavedSuccessfully'));
                        _modalManager.close();
                        abp.event.trigger('app.createOrEditModuleModalSaved');
                    }).always(function ()
                    {
                        _modalManager.setBusy(false);
                    });
            };
        };

    };
})(jQuery);