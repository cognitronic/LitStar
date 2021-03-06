﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitStar.Infrastructure
{
    public static class MessageBus<T> where T : EventArgs
    {
        public static event EventHandler<T> MessageReceived;
        public static void SendMessage(object sender, T message)
        {
            if (MessageReceived != null)
            {
                MessageReceived(sender, message);
            }
        }
    }
}
