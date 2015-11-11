class Bullet {
    PhysicsObject po;
    int id;
    int bulletType;
    int damage;
    float BULLET_SPEED = 700.0F;
    Player owner = null;
    bool isVisisble = true;
    //this.ttl = None
    int ttl; //time to live
    bool markedForRemoval;
    
    Bullet(ref Player owner) {
        //po = PhysicsObject(m=2.7, owner=this.
        po = PhysicsObject(m=2*1.7, owner=this);
        po.invulnerable = true;
        po.gravityFactor = 0.64;
        damage = 5;
        BULLET_SPEED = 700.0F;
	isVisisble = true;
	//this.ttl = None
	ttl = 120;

        markedForRemoval = false;
    }
        
    void update(ref Game game) {
        this.po.updatePhysics(game);
        if (this.po.pos.x < -con.BULLET_REMOVE_BORDER ||
                this.po.pos.x > game.screenw + con.BULLET_REMOVE_BORDER ||
                this.po.pos.y < -con.BULLET_REMOVE_BORDER ||
                this.po.pos.y > game.screenh + con.BULLET_REMOVE_BORDER ||
                (this.ttl != null && this.ttl <= 0)) {
            this.markedForRemoval = true;
            return 0;
        }
        
        if (game.vectorToMiddle(pos).len() < game.blackHoleSize) {
            game.blackHoleSize += con.BLACK_HOLE_INCREASE_BY_BULLET;
            this.markedForRemoval = true;
            return 0;
        }
        
            
        //Collision detection with players
        foreach (Player player in game.players) {
            if (this.owner != player.id && player.po &&
                    (this.po.pos-player.po.pos).len() < con.COLLISION_DIST) {
                player.po.hp -= this.damage;
                    
                //p=mv => m1 v1 = m2 v2 => v1 = m2 v2 / v1
                vDiff = (this.po.m * this.BULLET_SPEED) / player.po.m;
                player.po.v += this.po.v.normalize() * vDiff;
                player.po.gravityFactor += this.damage/100.0;
                //check for player dying
                if (player.po.hp <= 0) {
                    player.po.hp = player.po.maxHp;
                    debug.Log("Player with id=", player.id.toString() ,"died!");
                }
                    
                this.markedForRemoval = true;
                return 0;
            }
        }

        if (this.ttl != null) {
            this.ttl -= 1;
        }
    }
            
    void draw(ref Game game) {
        if (!this.isVisisble) { //has no body, can't draw
            return 0;
        }
        
        //x = this.po.pos.x
        //y = this.po.pos.y
            
        /*
        if self.bulletType == "strawberry" or self.bulletType is None:
            surface.blit(img["strawberry"],
                    dest=(x, y), area=None)
        elif self.bulletType == "banana":
            surface.blit(img["banana"],
                    dest=(x, y), area=None)
        else:
            surface.blit(img["banana"],
                    dest=(x, y), area=None)
        */
    }
} 
