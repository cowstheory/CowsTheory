class Bullet() {
    Bullet(owner) {
        //po = PhysicsObject(m=2.7, owner=this.
        po = PhysicsObject(m=2*1.7, owner=this.
        po.invulnerable = true
        id = None
        bulletType = None
        damage = 5
        BULLET_SPEED = 700.0
        owner = None
	isVisisble = true
	//this.ttl = None
	ttl = 120

        //this.po.gravityFactor = 0.0
        //this.po.gravityFactor = 0.4
        this.po.gravityFactor = 0.64
        
        this.markedForRemoval = false
    }
        
    void update(this. game, key) {
        this.po.updatePhysics(game);
        if (this.po.pos.x < -con.BULLET_REMOVE_BORDER ||
                this.po.pos.x > game.screenw + con.BULLET_REMOVE_BORDER ||
                this.po.pos.y < -con.BULLET_REMOVE_BORDER ||
                this.po.pos.y > game.screenh + con.BULLET_REMOVE_BORDER ||
                (this.ttl != null && this.ttl <= 0)) {
            this.markedForRemoval = true
            return
        }
        
        if game.vectorToMiddle(pos).len() < game.blackHoleSize {
            game.blackHoleSize += con.BLACK_HOLE_INCREASE_BY_BULLET
            this.markedForRemoval = true
            return
        }
            
        //Collision detection with players
        for player in game.players {
            if (this.owner != player.id and player.po &&
                    (this.po.pos-player.po.pos).len() < con.COLLISION_DIST):
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
                    
                this.markedForRemoval = true
                return 0
        }

        if (this.ttl != null) {
            this.ttl -= 1
        }
    }
            
    void draw(this. game, surface, img, fnt) {
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
