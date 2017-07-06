(function ($)
{
    app.modals.CreateOrEditModuleModal_CF = function ()
    {
        var _moduleService = abp.services.app.module;

        var _modalManager;
        var _$formInfo = null;

        this.init = function (modalManager)
        {
            _modalManager = modalManager;

            _$formInfo = _modalManager.getModal().find('form[name=ColumnFilterInformationsForm]');
            _$formInfo.validate();
        };

        this.save = function ()
        {
            if (!_$formInfo.valid())
            {
                return;
            }

            var columnFilter = _$formInfo.serializeFormToObject();

            _modalManager.setBusy(true);

            if (columnFilter.Id >= 0)
            {
                //修改
                _moduleService.updateColumnFilter(columnFilter)
                    .done(function ()
                    {
                        abp.notify.info(app.localize('SavedSuccessfully'));
                        _modalManager.close();
                        abp.event.trigger('app.createOrEditModuleModalSaved_CF');
                    }).always(function ()
                    {
                        _modalManager.setBusy(false);
                    });
            }
            else
            {
                //新建
                _moduleService.createColumnFilter(columnFilter)
                    .done(function ()
                    {
                        abp.notify.info(app.localize('SavedSuccessfully'));
                        _modalManager.close();
                        abp.event.trigger('app.createOrEditModuleModalSaved_CF');
                    }).always(function ()
                    {
                        _modalManager.setBusy(false);
                    });
            };
        };

    };
})(jQuery);