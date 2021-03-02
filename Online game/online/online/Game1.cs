#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

    public class Game1 : Microsoft.Xna.Framework.Game
    {

        enum OnlineState
        {
            AskingRole, //host or join
            Connecting,
            Playing
        }

        OnlineGame onlineGame;
        OnlineState state = OnlineState.AskingRole;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Drawit bg;


        bool imMisterH;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
     
            IsMouseVisible = true;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            #region General 
            spriteBatch = new SpriteBatch(GraphicsDevice);
            G.Initialize(graphics, GraphicsDevice, Content, spriteBatch); 
            #endregion

            #region bg
            bg = new Drawit(G.cm.Load<T2>("bg"),
                                        new V2(-500, -500),
                                        null,
                                        C.White,
                                        0,
                                        new V2(0, 0),
                                        new V2(G.scale ),
                                        SE.None,
                                        0);
            #endregion


            Window.Title = "Asking";

        }

        protected override void Update(GameTime gameTime)
        {
            G.update_input();

            switch (state)
            {
                case OnlineState.AskingRole:
                    if (G.ks.IsKeyDown(Keys.H))
                    {
                        onlineGame = new HostOnlineGame(6666);
                        state = OnlineState.Connecting;
                        onlineGame.OnConnection += OnlineGame_OnConnection;
                        imMisterH = true;

                    }
                    else if (G.ks.IsKeyDown(Keys.J))
                    {
                        onlineGame = new JoinOnlineGame("127.0.0.1", 6666);
                        state = OnlineState.Connecting;
                        onlineGame.OnConnection += OnlineGame_OnConnection;
                        imMisterH = false;
                    }
                    break;

                case OnlineState.Connecting:
                    Window.Title = "connecting";
                    //on connection invoke for the characters
                    //start the background thread for the two player
                    // change state for playing
                    break;

                case OnlineState.Playing:
                    onlineGame.hostChar.update();
                    onlineGame.joinChar.update();
                    if (G.ks.IsKeyDown(Keys.A))
                    {
                        G.zoom = MH.Lerp(G.zoom, 0.1f, 0.01f);
                    }

                    if (G.ks.IsKeyDown(Keys.D))
                    {
                        G.zoom = MH.Lerp(G.zoom, 5f, 0.001f);
                    }
                    break;
            }

       
            base.Update(gameTime);
        }

        private void OnlineGame_OnConnection()
        {
            Window.Title = "playing";
            state = OnlineState.Playing;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (state == OnlineState.Playing)
            {
                Window.Title = "drawing";
                Matrix view;
                if (imMisterH)
                    view = onlineGame.hostChar.mat;
                else
                    view = onlineGame.joinChar.mat;

                G.sb.Begin(transformMatrix: view) ;
                bg.Draw();
                onlineGame.hostChar.Draw();
                onlineGame.joinChar.Draw();
                G.sb.End();
            }

            base.Draw(gameTime);
        }

        
    }
}
