﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;

namespace Prism.Avalonia.Toolkit;

public class NotificationService : INotificationService
{
    private int _notificationTimeout = 5;
    private WindowNotificationManager? _notificationManager;

    /// <inheritdoc/>
    public int MaxItems { get; set; } = 4;

    /// <inheritdoc/>
    public int NotificationTimeout { get => _notificationTimeout; set => _notificationTimeout = (value < 0) ? 0 : value; }

    /// <inheritdoc/>
    public void SetHostWindow(TopLevel hostWindow)
    {
        var notificationManager = new WindowNotificationManager(hostWindow)
        {
            Position = NotificationPosition.BottomRight,
            MaxItems = 4,
            Margin = new Thickness(0, 0, 15, 40)
        };

        _notificationManager = notificationManager;
    }

    /// <inheritdoc/>
    public void Show(string title,
                     string message,
                     NotificationType type = NotificationType.Information,
                     Action? onClick = null,
                     Action? onClose = null)
    {
        if (_notificationManager is { } nm)
        {
            nm.Show(
                new Notification(
                    title,
                    message,
                    type,
                    TimeSpan.FromSeconds(_notificationTimeout),
                    onClick,
                    onClose));
        }
    }
}
