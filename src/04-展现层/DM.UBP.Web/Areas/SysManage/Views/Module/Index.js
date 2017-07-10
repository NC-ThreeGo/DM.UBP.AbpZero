//弹出图标选择窗口
//function openIconList()
//{
//    $('#modalwindowicon').window({ title: '@L("Edit")', iconCls: 'fa fa-pencil' }).window('open');
//    $('#modalwindowicon').parent("div").css("top", "50px");
//    $('#modalwindowicon').show();
//}

//由于按钮是否显示需要通过后台代码根据当前用户的权限才能得到，所以需要将这部分的js代码移植到.cshtml中，
//  由于在.cshtml中的js脚本需要调用这里定义的var 变量，所以需要把这些变量放到function ()外面，否则受限于js的变量作用域。
//定义在.js和.cshtml中js脚本都会用到的变量。


(function ()
{
    $(function ()
    {
        //初始化Abp控件
        var _moduleService = abp.services.app.module;
        var _$moduleTable = $('#ModulesTable');

       //初始化ModulesTable
        _$moduleTable.bootstrapTable({
            url: '/SysManage/Module/GetAllModuleList',
            toolbar: '#toolbar',
            sidePagination: 'client',
            cache: true,
            height: 550,

            //pagination: true,
            //pageNumber: 1,
            //pageSize: 10,
            //pageList: [10, 25, 50, 100],

            striped: true, //奇偶行是否区分
            singleSelect: true,//单选模式
            clickToSelect: true,

            treeView: true,
            treeId: "Id",
            treeField: "ModuleCode",
            treeRootLevel: 1,
            treeCollapseAll: true,
            //collapseIcon: "glyphicon glyphicon-triangle-right",//折叠样式
            //expandIcon: "glyphicon glyphicon-triangle-bottom",//展开样式

            onUncheck: function (row)
            {
                $("#divModuleOpt :input").attr("disabled", true);
                $("#divColumnFilter :input").attr("disabled", true);
            },
            onCheck: function (row)
            {
                var selectRow = _$moduleTable.bootstrapTable('getSelections');
                if (selectRow.length > 0)
                {
                    $("#divModuleOpt :input").attr("disabled", false);
                    $("#divColumnFilter :input").attr("disabled", false);
                    getModuleOpts();
                    getColumnFilters();
                }
            },

            rowStyle: function (row, index)
            {
                //这里有5个取值代表5中颜色['active', 'success', 'info', 'warning', 'danger'];
                var strclass = "";
                if (row.IsLeaf)
                {
                    strclass = 'success';//还有一个active
                }
                else
                {
                    //strclass = 'info';
                    return {};
                }
                return { classes: strclass }
            },
            columns: [
                {
                    field: 'state',
                    checkbox: true
                },
                {
                    title: 'ID',
                    field: 'Id',
                    width: 30,
                    halign: 'center',
                },
                {
                    title: app.localize("ModuleCode"),
                    field: 'ModuleCode',
                    width: 300,
                    halign: 'center',
                },
                {
                    title: app.localize("ModuleName"),
                    field: 'ModuleName',
                    width: 100,
                    halign: 'center',
                },
                {
                    title: app.localize("ParentId"),
                    field: 'ParentId',
                    width: 40,
                    halign: 'center',
                },
                {
                    title: 'Url',
                    field: 'Url',
                    width: 150,
                    halign: 'center',
                },
                {
                    title: app.localize("Icon"),
                    field: 'Icon',
                    width: 30,
                    halign: 'center',
                    formatter: function (value)
                    {
                        return "<div class='" + value + "'/>";
                    }
                },
                {
                    title: app.localize("Sort"),
                    field: 'Sort',
                    width: 30,
                    halign: 'center',
                },
                {
                    title: app.localize("Remark"),
                    field: 'Remark',
                    width: 100,
                    halign: 'center',
                },
                {
                    title: app.localize("EnabledMark"),
                    field: 'EnabledMark',
                    width: 30,
                    halign: 'center',
                    formatter: function (value)
                    {
                        if (value)
                        {
                            return '<span class="label label-success">' + app.localize('Yes') + '</span>';
                        } else
                        {
                            return '<span class="label label-default">' + app.localize('No') + '</span>';
                        }
                    }
                },
                {
                    title: app.localize("IsLast"),
                    field: 'IsLast',
                    width: 30,
                    halign: 'center',
                    formatter: function (value)
                    {
                        if (value)
                        {
                            return '<span class="label label-success">' + app.localize('Yes') + '</span>';
                        } else
                        {
                            return '<span class="label label-default">' + app.localize('No') + '</span>';
                        }
                    }
                },
                {
                    title: app.localize("MultiTenancySide"),
                    field: 'MultiTenancySide',
                    width: 40,
                    halign: 'center',
                },
            ]
        });


        function getModules(reload)
        {
            if (reload)
            {
                _$moduleTable.bootstrapTable('refresh');
            } else
            {
                _$moduleTable.bootstrapTable('load');
            }
        }

        var _createModal = new app.ModalManager({
            viewUrl: abp.appPath + 'SysManage/Module/CreateModal',
            scriptUrl: abp.appPath + 'Areas/SysManage/Views/Module/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditModuleModal'
        });

        var _editModal = new app.ModalManager({
            viewUrl: abp.appPath + 'SysManage/Module/EditModal',
            scriptUrl: abp.appPath + 'Areas/SysManage/Views/Module/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditModuleModal'
        });

        $('#CreateButton').click(function ()
        {
            var row = _$moduleTable.bootstrapTable('getSelections');
            _createModal.open({ parentId: row.length > 0 ? row[0].Id : "" });
        });

        $('#EditButton').click(function ()
        {
            var row = _$moduleTable.bootstrapTable('getSelections');
            if (row.length == 0)
            {
                abp.message.error(app.localize("PlaseChooseToOperatingRecords"));
                return;
            }
            _editModal.open({ id: row[0].Id });
        });

        abp.event.on('app.createOrEditModuleModalSaved', function ()
        {
            getModules(true);
        });


        //模块操作码：----------------------------------------------------------
        var _$moduleOptTable = $('#ModuleOptsTable');
        $("#divModuleOpt :input").attr("disabled", true);

        var _createModal_Opt = new app.ModalManager({
            viewUrl: abp.appPath + 'SysManage/Module/CreateModal_Operate',
            scriptUrl: abp.appPath + 'Areas/SysManage/Views/Module/_CreateOrEditModal_Opt.js',
            modalClass: 'CreateOrEditModuleModal_Opt'
        });

        var _editModal_Opt = new app.ModalManager({
            viewUrl: abp.appPath + 'SysManage/Module/EditModal_Operate',
            scriptUrl: abp.appPath + 'Areas/SysManage/Views/Module/_CreateOrEditModal_Opt.js',
            modalClass: 'CreateOrEditModuleModal_Opt'
        });
        
        function getModuleOpts(reload)
        {
            if (reload)
            {
                _$moduleOptTable.jtable('reload');
            }
            else
            {
                var row = _$moduleTable.bootstrapTable('getSelections');
                _$moduleOptTable.jtable('load', {
                    moduleId: row.length > 0 ? row[0].Id : -1
                });
            }
        }

        //由于需要通过后台代码判断是否显示action的item，所以需要将.jtable()的初始化代码移到.cshtml中。
        //  否则返过来也可以：在.cshtml中定义相关权限的变量（根据后台代码赋值），然后这里调用。
        _$moduleOptTable.jtable({
            title: app.localize('ModuleOpt'),
            actions: {
                listAction: {
                    method: _moduleService.getModuleOperates
                }
            },

            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    type: 'record-actions',
                    cssClass: 'btn btn-xs btn-primary blue',
                    text: '<i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span>',
                    items: [
                        {
                            text: app.localize('Edit'),
                            visible: function ()
                            {
                                //return _permissions.edit;
                                return abp.auth.hasPermission(_optPerms.Edit);
                            },
                            action: function (data)
                            {
                                _editModal_Opt.open({ id: data.record.id });
                            }
                        }, {
                            text: app.localize('Delete'),
                            visible: function ()
                            {
                                //return _permissions.delete;
                                return true;
                            },
                            action: function (data)
                            {
                                //deleteUser(data.record);
                            }
                        }]
                },
                operateCode: {
                    title: app.localize('OperateCode'),
                    width: '80',
                    initialSortingDirection: 'DESC'
                },
                operateName: {
                    title: app.localize('OperateName'),
                    width: '80'
                },
                isValid: {
                    title: app.localize('IsValid'),
                    width: '80',
                    display: function (data)
                    {
                        if (data.record.isValid)
                        {
                            return '<span class="label label-success">' + app.localize('Yes') + '</span>';
                        } else
                        {
                            return '<span class="label label-default">' + app.localize('No') + '</span>';
                        }
                    }
                },
                moduleId: {
                    title: app.localize('ModuleId'),
                    width: '80'
                },
                sort: {
                    title: app.localize('Sort'),
                    width: '80'
                },
           }
        });

        $('#CreateOptButton').click(function ()
        {
            var row = _$moduleTable.bootstrapTable('getSelections');
            if (row.length == 0)
            {
                abp.message.warn(app.localize("PlaseChooseToOperatingRecords"));
                return;
            }
            if (!row[0].IsLast)
            {
                abp.message.warn("只有最后一项的菜单才能设置操作码!");
                return;
            }
            _createModal_Opt.open({ moduleId: row.length > 0 ? row[0].Id : "" });
        });

        abp.event.on('app.createOrEditModuleModalSaved_Opt', function ()
        {
            getModuleOpts(true);
        });


        //模块列过滤器：----------------------------------------------------------
        var _$columnFilterTable = $('#ColumnFiltersTable');
        $("#divColumnFilter :input").attr("disabled", true);

        var _createModal_CF = new app.ModalManager({
            viewUrl: abp.appPath + 'SysManage/Module/CreateModal_ColumnFilter',
            scriptUrl: abp.appPath + 'Areas/SysManage/Views/Module/_CreateOrEditModal_CF.js',
            modalClass: 'CreateOrEditModuleModal_CF'
        });

        var _editModal_CF = new app.ModalManager({
            viewUrl: abp.appPath + 'SysManage/Module/EditModal_ColumnFilter',
            scriptUrl: abp.appPath + 'Areas/SysManage/Views/Module/_CreateOrEditModal_CF.js',
            modalClass: 'CreateOrEditModuleModal_CF'
        });

        function getColumnFilters(reload)
        {
            if (reload)
            {
                _$columnFilterTable.jtable('reload');
            }
            else
            {
                var row = _$moduleTable.bootstrapTable('getSelections');
                _$columnFilterTable.jtable('load', {
                    moduleId: row.length > 0 ? row[0].Id : -1
                });
            }
        }

        //由于需要通过后台代码判断是否显示action的item，所以需要将.jtable()的初始化代码移到.cshtml中。
        //  否则返过来也可以：在.cshtml中定义相关权限的变量（根据后台代码赋值），然后这里调用。
        _$columnFilterTable.jtable({
            title: app.localize('ColumnFilter'),
            actions: {
                listAction: {
                    method: _moduleService.getColumnFilters
                }
            },

            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    type: 'record-actions',
                    cssClass: 'btn btn-xs btn-primary blue',
                    text: '<i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span>',
                    items: [
                        {
                            text: app.localize('Edit'),
                            visible: function ()
                            {
                                return true;
                            },
                            action: function (data)
                            {
                                _editModal_CF.open({ id: data.record.id });
                            }
                        }, {
                            text: app.localize('Delete'),
                            visible: function ()
                            {
                                return true;
                            },
                            action: function (data)
                            {
                                //deleteUser(data.record);
                            }
                        }]
                },
                columnCode: {
                    title: app.localize('ColumnCode'),
                    width: '80',
                    initialSortingDirection: 'DESC'
                },
                columnName: {
                    title: app.localize('ColumnName'),
                    width: '80'
                },
                isValid: {
                    title: app.localize('IsValid'),
                    width: '80',
                    display: function (data)
                    {
                        if (data.record.isValid)
                        {
                            return '<span class="label label-success">' + app.localize('Yes') + '</span>';
                        } else
                        {
                            return '<span class="label label-default">' + app.localize('No') + '</span>';
                        }
                    }
                },
                moduleId: {
                    title: app.localize('ModuleId'),
                    width: '80'
                },
                sort: {
                    title: app.localize('Sort'),
                    width: '80'
                },
            }
        });

        $('#CreateColumnFilterButton').click(function ()
        {
            var row = _$moduleTable.bootstrapTable('getSelections');
            if (row.length == 0)
            {
                abp.message.warn(app.localize("PlaseChooseToOperatingRecords"));
                return;
            }
            if (!row[0].IsLast)
            {
                abp.message.warn("只有最后一项的菜单才能设置列过滤器!");
                return;
            }
           _createModal_CF.open({ moduleId: row.length > 0 ? row[0].Id : "" });
        });

        abp.event.on('app.createOrEditModuleModalSaved_CF', function ()
        {
            getColumnFilters(true);
        });
    });
})();