@Html.DevExpress().GridView(Sub(settings)
                                     settings.Name = "GridView"

                                     settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartial"}
                                     settings.SettingsBehavior.ConfirmDelete = True


                                     settings.SettingsPager.Visible = True
                                     settings.Settings.ShowGroupPanel = True
                                     settings.Settings.ShowFilterRow = True
                                     settings.SettingsBehavior.AllowSelectByRowClick = True

                                     settings.SettingsAdaptivity.AdaptivityMode = GridViewAdaptivityMode.Off
                                     settings.SettingsAdaptivity.AdaptiveColumnPosition = GridViewAdaptiveColumnPosition.Right
                                     settings.SettingsAdaptivity.AdaptiveDetailColumnCount = 1
                                     settings.SettingsAdaptivity.AllowOnlyOneAdaptiveDetailExpanded = False
                                     settings.SettingsAdaptivity.HideDataCellsAtWindowInnerWidth = 0
                                 End Sub).Bind(Model).GetHtml()

