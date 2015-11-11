public class Powerup {
    PhysicsObject po;
    int hp;
    int maxHp;
    int id;
    String type;
    bool isVisible;
    int ttl;
    
    public Powerup(Vector3 pos_, Vector3 v_) {
        po = new PhysicsObject(5.0F, Vector3(), Vector3());
        maxHp = 5;
        hp = self.maxHp;
        po.invulnerable = true;
        id = null;
        owner = null;
        if (Random.Range (0.0F, 1.0F) > 0.5F) {
            type = "health";
        } else {
            type = "gun";
        }
        isVisible = true;
	ttl = null;
        po.gravityFactor = 0.6;
        markedForRemoval = false;
    }
        
    //TODO: this is almost identical to Player.respawn()
    void respawn(ref Game game) {
        self.po.gravityFactor = con.GRAVITY_FACTOR_POWERUP_DEFAULT;
        
        float angle = Random.Range(0.0F, 2.0F*Mathf.PI);
        float ringRadius = 300.0F;
        float spawnRadius = 200.0F + ringRadius * random.random();
        float x = spawnRadius * math.cos(angle);
        float y = spawnRadius * math.sin(angle);
        
        self.po.pos = Vector3(x,y);
        float spawnVelocity = 120.0F;
        self.po.v = Vector3(spawnVelocity*math.sin(angle+math.pi/2.0F),
                spawnVelocity*math.cos(angle+math.pi/2.0F));
        if (Random.Range (0.0F, 1.0F) > 0.5F) {
            self.po.v *= -1;
        }
        self.po.f = V3();
        self.po.a = V3();
        
        self.po.hp = self.po.maxHp;
    }
    
    void update(ref Game game) {
        self.po.updatePhysics(game);
        pos = self.po.pos;
        if (pos.x < -con.BULLET_REMOVE_BORDER ||
                pos.x > game.screenw + con.BULLET_REMOVE_BORDER ||
                pos.y < -con.BULLET_REMOVE_BORDER ||
                pos.y > game.screenh + con.BULLET_REMOVE_BORDER ||
                (pos - V3(game.screenw/2.0, game.screenh/2.0)).len() < 48.0 ||
                self.ttl != null && self.ttl <= 0) {
            self.markedForRemoval = true;
            return;
        }
        
        //Collision detection with players
        foreach (Player player in players) {
            if ((po.pos - player.po.pos).magnitude < con.POWERUP_PICKUP_DIST) {
                if (type == "health") {
                    player.po.gravityFactor = Mathf.Max(1.0, player.po.gravityFactor - 0.25);
                } else if (type == "gun") {
                    player.TIME_BETWEEN_SHOTS = Mathf.Max(1, player.TIME_BETWEEN_SHOTS - 2);
                }
                    
                self.markedForRemoval = true;
                return;
            }
        }
        
        if (self.ttl != null && self.ttl <= 0) {
            self.markedForRemoval = true;
        } else {
            if (self.ttl != null) {
                self.ttl -= 1;
            }
        }
    }
    
    void draw(ref Game game) {
        /*
        x, y = self.po.pos.x, self.po.pos.y
            
        if self.type == "health" or self.type is None:
            surface.blit(img["powerup_health"],
                    dest=(x, y), area=None)
        if self.type == "gun":
            surface.blit(img["powerup_gun"],
                    dest=(x, y), area=None)
        */
    }
}
