using UnityEngine;

public class Bullet {
    PhysicsObject po;
    int id;
    int bulletType;
    int damage;
    float BULLET_SPEED = 700.0F;
    Player owner = null;
    bool isVisisble = true;
    //this.ttl = None
    int ttl; //time to live
    public bool markedForRemoval;
    
    public Bullet(ref Player owner, Vector3 pos, Vector3 vel) {
        //po = PhysicsObject(m=2.7, owner=this.
		// TODO
        po = new PhysicsObject(2*1.7F, pos, vel);
        po.invulnerable = true;
        po.gravityFactor = 0.64F;
        damage = 5;
        BULLET_SPEED = 700.0F;
		isVisisble = true;
		//this.ttl = null
		ttl = 120;

        markedForRemoval = false;
    }
        
    public void update(ref Game game) {
        this.po.updatePhysics(ref game);
		// TODO: Check for out of bounds and ttl
//        if (this.po.pos.x < -con.BULLET_REMOVE_BORDER ||
//                this.po.pos.x > game.screenw + con.BULLET_REMOVE_BORDER ||
//                this.po.pos.y < -con.BULLET_REMOVE_BORDER ||
//                this.po.pos.y > game.screenh + con.BULLET_REMOVE_BORDER ||
//                (this.ttl != null && this.ttl <= 0)) {
//            this.markedForRemoval = true;
//            return;
//        }
        
        if (game.vectorToMiddle(po.pos).magnitude < game.blackHoleSize) {
            game.blackHoleSize += con.BLACK_HOLE_INCREASE_BY_BULLET;
            this.markedForRemoval = true;
            return;
        }
        
            
        //Collision detection with players
        foreach (Player player in game.players) {
            if (owner != null && owner.id != player.id &&
                    (this.po.pos-player.po.pos).magnitude < con.COLLISION_DIST) {
                player.po.hp -= this.damage;
                    
                //p=mv => m1 v1 = m2 v2 => v1 = m2 v2 / v1
                float vDiff = (this.po.m * this.BULLET_SPEED) / player.po.m;
                player.po.v += this.po.v.normalized * vDiff;
                player.po.gravityFactor += this.damage/100.0F;
                //check for player dying
                if (player.po.hp <= 0) {
                    player.po.hp = player.po.maxHp;
                    Debug.Log("Player with id=" + player.id + "died!");
                }
                    
                this.markedForRemoval = true;
                return;
            }
        }

        if (this.ttl != null) {
            this.ttl -= 1;
        }
    }
            
    public void draw(ref Game game) {
        if (!this.isVisisble) { //has no body, can't draw
            return;
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
