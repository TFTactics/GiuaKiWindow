using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDiCanh
{
    public class Enemy
    {
        private int health;
        private int damage;
        public Enemy()
        {

        }
        public Enemy(int HP, int DMG)
        {
            health = HP;
            damage = DMG;
        }
    }

    public class BOSS : Enemy
    {
        public BOSS(int HP, int DMG) : base(HP, DMG) { }
    }

    public class tiny : Enemy
    {
        public tiny(int HP, int DMG) : base(HP, DMG) { }
    }
}
