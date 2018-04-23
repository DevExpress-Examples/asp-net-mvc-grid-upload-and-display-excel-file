@Html.DevExpress().GridView(Sub(settings)
                                     settings.Name = "GridView"

                                     settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartial"}
                                     settings.SettingsBehavior.ConfirmDelete = true


                                     settings.SettingsPager.Visible = true
                                     settings.Settings.ShowGroupPanel = true
                                     settings.Settings.ShowFilterRow = true
                                     settings.SettingsBehavior.AllowSelectByRowClick = true

                                     settings.SettingsAdaptivity.AdaptivityMode = GridViewAdaptivityMode.Off
                                     settings.SettingsAdaptivity.AdaptiveColumnPosition = GridViewAdaptiveColumnPosition.Right
                                     settings.SettingsAdaptivity.AdaptiveDetailColumnCount = 1
                                     settings.SettingsAdaptivity.AllowOnlyOneAdaptiveDetailExpanded = false
                                     settings.SettingsAdaptivity.HideDataCellsAtWindowInnerWidth = 0
                                 End Sub).Bind(Model).GetHtml()
