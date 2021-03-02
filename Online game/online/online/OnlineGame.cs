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
    public delegate void OnConnectionHandler();

    abstract class OnlineGame
    {
        protected BinaryReader reader;
        protected BinaryWriter writer;

        protected Thread thread;

        protected TcpClient client;

        protected int port;

        public Character hostChar, joinChar;

        public  event OnConnectionHandler OnConnection;

        #region funcs to overide
        protected abstract void InitChars();


        protected abstract void SocketThread();
        #endregion

       
        protected void RaiseOnConnectionEvent()
        {
            OnConnection?.Invoke();
          
        }

        public void StartCommunication()
        {
            thread = new Thread(SocketThread);
            thread.IsBackground = true;
            thread.Start();

        }

        protected void ReadAndUpdateCharacter(Character c)
        {
            c.pos.X = reader.ReadSingle();
            c.pos.Y = reader.ReadSingle();
            c.rot = reader.ReadSingle();
        }

        protected void WriteCharacterData(Character c)
        {
            writer.Write(c.pos.X);
            writer.Write(c.pos.Y);
            writer.Write(c.rot);
        }

    }
}
