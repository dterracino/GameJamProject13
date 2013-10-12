﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameSlamProject
{
    public class Enemy : Sprite
    {
        #region CONSTANTS
        const int DISTANCE_MOVED = 5; // How far we want the unit to move on a tick.
        #endregion

        // FIELDS -----------------------------------------------------------------------------------------------------

        /// <summary>
        /// int representing the enemy's health.
        /// </summary>
        public int health;

        /// <summary>
        /// int representing how much damage the player can do.
        /// </summary>
        public int damage;

        /// <summary>
        /// Constructor for an Enemy.
        /// </summary>
        /// <param name="loadedTx"> Texture represents the image file used for that enemy. </param>
        public Enemy(Texture2D loadedTx) : base(loadedTx)
        {
            // Empty constructor, since all subclasses have particular fields.
        }

        /// <summary>
        /// Moves the Enemy instance towards the player (at all times).
        /// </summary>
        public void move(Sprite player)
        {
            if (player.pos.X < this.pos.X)
            {
                this.pos.X = this.pos.X - DISTANCE_MOVED;
            }
            else if (player.pos.X > this.pos.X)
            {
                this.pos.X = this.pos.X + DISTANCE_MOVED;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void collide(Sprite player)
        {
            if (player.rect.Intersects(this.rect))
            {
                // Effects a colision has on a player.
                player.health -= 1;
                player.vel.X -= 1;

            }
        }
    }
}