﻿using Content.Client.Stylesheets;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Utility;

namespace Content.Client.Replay.UI.Loading;

[GenerateTypedNameReferences]
public sealed partial class ReplayLoadingFailedControl : Control
{
    public ReplayLoadingFailedControl(IStylesheetManager stylesheet)
    {
        RobustXamlLoader.Load(this);

        Stylesheet = stylesheet.SheetSpace;
        LayoutContainer.SetAnchorPreset(this, LayoutContainer.LayoutPreset.Wide);
    }

    public void SetData(Exception exception, Action? cancelPressed, Action? retryPressed)
    {
        ReasonLabel.SetMessage(
            FormattedMessage.FromUnformatted(Loc.GetString("replay-loading-failed", ("reason", exception))));

        if (cancelPressed != null)
        {
            CancelButton.Visible = true;
            CancelButton.OnPressed += _ =>
            {
                cancelPressed();
            };
        }

        if (retryPressed != null)
        {
            RetryButton.Visible = true;
            RetryButton.OnPressed += _ =>
            {
                retryPressed();
            };
        }
    }
}