﻿using System.ComponentModel;

namespace StackExchange.Redis;

public partial class ConnectionMultiplexer
{
    /// <summary>
    /// No longer used.
    /// </summary>
    [Obsolete("No longer used, will be removed in 3.0.")]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public static TaskFactory Factory { get => Task.Factory; set { } }

    /// <summary>
    /// Gets or sets whether asynchronous operations should be invoked in a way that guarantees their original delivery order.
    /// </summary>
    [Obsolete("Not supported; if you require ordered pub/sub, please see " + nameof(ChannelMessageQueue) + ", will be removed in 3.0", false)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public bool PreserveAsyncOrder { get => false; set { } }
}
