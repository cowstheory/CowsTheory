class PhysicsObject {
    float m;
    Vector3 pos;
    Vector3 v;
    Vector3 a;
    Vector3 f;
    
    int hp;
    int maxHp;
    bool invulnerable;
        
    PhysicsObject(float m_, Vector3 pos_, Vector3 v_) {
        this.m = m_;
        this.pos = pos_;
        this.v = v_;
        this.a = Vector3();
        this.f = Vector3();
        this.owner = owner;
        
        this.hp = 100;
        this.maxHp = 100;
        this.invulnerable = True;
        
        this.gravityFactor = 1.0F; //0.0 means don't apply gravity
    }
    
    void updatePhysics(ref Game game) {
        //this.f += game.gravity * this.gravityFactor * this.m
        middleOfScreen = V3(game.screenw/2.0, game.screenh/2.0);
        float pullStrength = con.BLACK_HOLE_GRAVITY_STRENGTH * this.gravityFactor**2.0;
        Vector3 f = (middleOfScreen - this.pos) * pullStrength;
        
        if (game.vectorToMiddle(this.pos).len() < con.EVENT_HORIZON_RADIUS) {
            this.f += f;
        } else {
            this.f += f*0.25;
        }
        
        //this.v += f * 1e-4 * (this.gravityFactor)**2
        
        this.v += Vector3();
        
        this.a = this.f / this.m;
        this.f = Vector3();
        this.v += this.a * game.dt;
        this.pos += this.v * game.dt;
}

