(function ($)
{
    //选择图标对话框
    //var _iconListModal = new app.ModalManager({
    //    viewUrl: abp.appPath + 'Mpa/Layout/IconList',
    //    scriptUrl: abp.appPath + 'Areas/Mpa/Views/Layout/_IconList.js',
    //    modalClass: 'IconListModal',
    //    modalContentCssClass: 'modal-content-iconlist',
    //});

    //$('#Iconic').click(function ()
    //{
    //    _iconListModal.open(null, function (result)
    //    {
    //        $("#Iconic").attr("class", result);
    //        $("#Icon").val(result);
    //    });
    //});


    app.modals.CreateOrEditModuleModal_Opt = function ()
    {
        var _moduleService = abp.services.app.module;

        var _modalManager;
        var _$formInfo = null;

        this.init = function (modalManager)
        {
            _modalManager = modalManager;

            _$formInfo = _modalManager.getModal().find('form[name=ModuleOptInformationsForm]');
            _$formInfo.validate();
        };

        this.save = function ()
        {
            if (!_$formInfo.valid())
            {
                return;
            }

            var moduleOpt = _$formInfo.serializeFormToObject();

            _modalManager.setBusy(true);

            if (moduleOpt.Id >= 0)
            {
                //修改
                _moduleService.updateModuleOperate(moduleOpt)
                    .done(function ()
                    {
                        abp.notify.info(app.localize('SavedSuccessfully'));
                        _modalManager.close();
                        abp.event.trigger('app.createOrEditModuleModalSaved_Opt');
                    }).always(function ()
                    {
                        _modalManager.setBusy(false);
                    });
            }
            else
            {
                //新建
                _moduleService.createModuleOperate(moduleOpt)
                    .done(function ()
                    {
                        abp.notify.info(app.localize('SavedSuccessfully'));
                        _modalManager.close();
                        abp.event.trigger('app.createOrEditModuleModalSaved_Opt');
                    }).always(function ()
                    {
                        _modalManager.setBusy(false);
                    });
            };
        };

    };
})(jQuery);