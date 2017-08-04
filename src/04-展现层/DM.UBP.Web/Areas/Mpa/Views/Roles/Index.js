﻿(function () {
    $(function () {

        var _$rolesTable = $('#RolesTable');
        var _roleService = abp.services.app.role;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.Roles.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.Roles.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.Roles.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/Roles/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/Roles/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditRoleModal'
        });

        _$rolesTable.jtable({

            title: app.localize('Roles'),

            actions: {
                listAction: {
                    method: _roleService.getRoles
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
                    items: [{
                        text: app.localize('Edit'),
                        visible: function () {
                            return _permissions.edit;
                        },
                        action: function (data) {
                            _createOrEditModal.open({ id: data.record.id });
                        }
                    }, {
                        text: app.localize('Delete'),
                        visible: function (data) {
                            return !data.record.isStatic && _permissions.delete;
                        },
                        action: function (data) {
                            deleteRole(data.record);
                        }
                    }]
                },
                displayName: {
                    title: app.localize('RoleName'),
                    width: '35%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.displayName + " &nbsp; ");

                        if (data.record.isStatic) {
                            $span.append('<span class="label label-info" data-toggle="tooltip" title="' + app.localize('StaticRole_Tooltip') + '" data-placement="top">' + app.localize('Static') + '</span>&nbsp;');
                        }

                        if (data.record.isDefault) {
                            $span.append('<span class="label label-default" data-toggle="tooltip" title="' + app.localize('DefaultRole_Description') + '" data-placement="top">' + app.localize('Default') + '</span>&nbsp;');
                        }

                        $span.find('[data-toggle=tooltip]').tooltip();

                        return $span;
                    }
                },
                creationTime: {
                    title: app.localize('CreationTime'),
                    width: '35%',
                    display: function (data) {
                        return moment(data.record.creationTime).format('L');
                    }
                }
            }

        });

        function deleteRole(role) {
            abp.message.confirm(
                app.localize('RoleDeleteWarningMessage', role.displayName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _roleService.deleteRole({
                            id: role.id
                        }).done(function () {
                            getRoles();
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        };

        $('#CreateNewRoleButton').click(function () {
            _createOrEditModal.open();
        });

        $('#RefreshRolesButton').click(function (e) {
            e.preventDefault();
            getRoles();
        });

        function getRoles() {
            _$rolesTable.jtable('load', { permission: $('#PermissionSelectionCombo').val() });
        }

        abp.event.on('app.createOrEditRoleModalSaved', function () {
            getRoles();
        });

        getRoles();
    });
})();