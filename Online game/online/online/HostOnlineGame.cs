#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion
#region Shortcuts
using GDM = Microsoft.Xna.Framework.GraphicsDeviceManager;
using GD = Microsoft.Xna.Framework.Graphics.GraphicsDevice;
using CM = Microsoft.Xna.Framework.Content.ContentManager;
using SB = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using V2 = Microsoft.Xna.Framework.Vector2;
using V3 = Microsoft.Xna.Framework.Vector3;
using MH = Microsoft.Xna.Framework.MathHelper;
using MX = Microsoft.Xna.Framework.Matrix;
using T2 = Microsoft.Xna.Framework.Graphics.Texture2D;
using F = System.Single;
using SE = Microsoft.Xna.Framework.Graphics.SpriteEffects;
using REC = Microsoft.Xna.Framework.Rectangle;
using KS = Microsoft.Xna.Framework.Input.KeyboardState;
using MS = Microsoft.Xna.Framework.Input.MouseState;
using C = Microsoft.Xna.Framework.Color;
using BSM = Microsoft.Xna.Framework.Graphics.BlendState;
using SSM = Microsoft.Xna.Framework.Graphics.SpriteSortMode;
#endregion

namespace online
{
    class HostOnlineGame : OnlineGame
    {

        public HostOnlineGame(int port)
        {
            this.port = port;
            InitChars();
            StartCommunication();
        }

        protected override void InitChars()
        {


            hostChar = new ControllableCharacter(G.cm.Load<T2>("roki"),
                                        new V2(900, 300 )* G.scale,
                                        null,
                                        C.GreenYellow,
                                        0,
                                        new V2(515, 548),
                                        new V2(0.25f, 0.2f),
                                        SE.None,
                                        0);

            joinChar = new Character(G.cm.Load<T2>("roki"),
                                        new V2(300 , 300 ) * G.scale,
                                        null,
                                        C.White,
                                        0,
                                        new V2(515, 548),
                                        new V2(0.2f, 0.25f),
                                        SE.None,
                                        0);
        }

        protected override void SocketThread()
        {
            TcpListener hostl = new TcpListener(IPAddress.Any, port);
            hostl.Start();

            this.client = hostl.AcceptTcpClient(); //blockimg

            base.RaiseOnConnectionEvent();

            reader = new BinaryReader(client.GetStream());
            writer = new BinaryWriter(client.GetStream());

            while (true)
            {
                base.WriteCharacterData(hostChar);
                base.ReadAndUpdateCharacter(joinChar);

                Thread.Sleep(10);
            }
        }


        
    }
}
