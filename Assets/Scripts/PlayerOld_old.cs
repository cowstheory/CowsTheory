using UnityEngine;

public class Player : MonoBehaviour {
    public PhysicsObject po;
    public int id;
    // Gun[] guns;
    public int livesLeft;
	public GameObject go;

    public Player() {
        go = Object.Instantiate(go);
        po = new PhysicsObject(50.0F, new Vector3(), new Vector3());
        po.invulnerable = false;
        livesLeft = con.NUM_PLAYER_LIVES;
//        respawn(game);
    }

    void respawn(ref Game game) {
        /*TIME_BETWEEN_SHOTS = 20
        if favoriteFruit == "shotgun":
            TIME_BETWEEN_SHOTS = 42
        timeUntilNextShot = 0
        timeUntilNextShot2 = 0*/

        po.gravityFactor = con.GRAVITY_FACTOR_PLAYER_DEFAULT;

        //TODO: This... isn't right. Fix the math
        //  (e.g. spawn at a circle, with a velocity perpendicular to
        //  the vector between the player and the black hole)
        //spawn in a circle around the middle
		float angle = Random.Range(0.0F, 2.0F*Mathf.PI);
        float ringRadius = 50.0F;
        float spawnRadius = Mathf.Max(game.blackHoleSize + 70.0F, 200.0F)
                + ringRadius * Random.Range(0.0F, 1.0F);
		// TODO: Add middle of screen
//        x = con.SCREEN_W/2.0 + spawnRadius * Mathf.Cos(angle);
//        y = con.SCREEN_H/2.0 + spawnRadius * Mathf.Sin(angle);
        float x = spawnRadius * Mathf.Cos(angle);
        float y = spawnRadius * Mathf.Sin(angle);

        po.pos = new Vector3(x,y,0);
        float spawnVelocity = 300.0F;
        po.v = new Vector3(spawnVelocity*Mathf.Sin(angle), spawnVelocity*Mathf.Cos(angle), 0.0F);
        if (Random.Range (0.0F, 1.0F) > 0.5F) {
            po.v *= -1;
        }
        po.f = new Vector3();
        po.a = new Vector3();

        po.hp = po.maxHp;
    }

    public void update(Game game) {
        po.updatePhysics(ref game);
		// TODO: add collision with black hole
//        if (game.vectorToMiddle(po.pos + new Vector3(hw, hh)).magnitude
//                < game.blackHoleSize) {
//            respawn(game);
//            livesLeft -= 1;
//            game.blackHoleSize += con.BLACK_HOLE_INCREASE_BY_PLAYER;
//        }

        //TODO: add bouncy walls
//        if (po.pos.x < 0 && po.v.x < 0) {
//            po.v.x *= con.BOUNCE_FACTOR_ON_WALLS;
//        } else if(po.pos.x + w >= game.screenw && po.v.x > 0) {
//            po.v.x *= con.BOUNCE_FACTOR_ON_WALLS;
//        }
//
//        if (po.pos.y < 0 && po.v.y < 0) {
//            po.v.y *= con.BOUNCE_FACTOR_ON_WALLS;
//        } else if(po.pos.y + h >= game.screenh && po.v.y > 0) {
//            po.v.y *= con.BOUNCE_FACTOR_ON_WALLS;
//        }


        po.v *= con.PLAYER_DRAG;

        updateControls(ref game);
    }

    void updateControls(ref Game game) {
        //TODO: Add controls. Use this.id to see which control corresponds to which player
        /*self.timeUntilNextShot = max(0, self.timeUntilNextShot-1)
        self.timeUntilNextShot2 = max(0, self.timeUntilNextShot2-1)

        #print self.timeUntilNextShot

        if not self.po:
            return

        #shooting
        for gun in range(self.numGuns):
            left, right, up, down = 0, 0, 0, 0
            if self.id == 0: #player 1
                if gun == 0:
                    if key[K_w]: up = 1.
                    if key[K_s]: down = 1.
                    if key[K_a]: left = 1.
                    if key[K_d]: right = 1.
                elif gun == 1:
                    if key[K_t]: up = 1.
                    if key[K_g]: down = 1.
                    if key[K_f]: left = 1.
                    if key[K_h]: right = 1.

            elif self.id == 1: #player 2
                if gun == 0:
                    if key[K_UP]: up = 1.
                    if key[K_DOWN]: down = 1.
                    if key[K_LEFT]: left = 1.
                    if key[K_RIGHT]: right = 1.
                elif gun == 1:
                    if key[K_i]: up = 1.
                    if key[K_k]: down = 1.
                    if key[K_j]: left = 1.
                    if key[K_l]: right = 1.
            elif self.id == 2 and gun == 0:
                pass
                #if key[K_i]: up = 1.
                #if key[K_k]: down = 1.
                #if key[K_j]: left = 1.
                #if key[K_l]: right = 1.
            elif self.id == 3 and gun == 0:
                pass
                #if key[K_t]: up = 1.
                #if key[K_g]: down = 1.
                #if key[K_f]: left = 1.
                #if key[K_h]: right = 1.

            if left and right:
                left, right = 0, 0
            if up and down:
                up, down = 0, 0

            numHeld = float(left+right+up+down)
            if numHeld < 1:
                continue

            if numHeld > 1:
                s = numHeld**0.5
                left /= s
                right /= s
                up /= s
                down /= s

            dx, dy = right - left, down - up

            if gun == 0 and self.timeUntilNextShot > 0 \
                    or gun == 1 and self.timeUntilNextShot2 > 0:
                continue

            if gun == 0:
                self.timeUntilNextShot += self.TIME_BETWEEN_SHOTS
            elif gun == 1:
                if self.favoriteFruit == "shotgun": #ugly special case
                    self.timeUntilNextShot2 += 20
                else:
                    self.timeUntilNextShot2 += self.TIME_BETWEEN_SHOTS

            if self.favoriteFruit == "shotgun" and gun != 1:
                for degree in range(-10, 10, 3):
                    a = math.radians(degree)

                    b = Bullet()
                    b.po.pos = copy.copy(self.po.pos)
                    b.po.v = copy.copy(self.po.v) + (V3(dx, dy).rotate(a)) \
                            * b.BULLET_SPEED
                    b.owner = self.id
                    b.bulletType = self.favoriteFruit
                    game.bullets.append(b)

                    vDiff = -0.3*(b.po.m * b.BULLET_SPEED) / self.po.m
                    self.po.v += V3(dx, dy) * vDiff
            else:
                b = Bullet()
                b.po.pos = copy.copy(self.po.pos)
                b.po.v = copy.copy(self.po.v) + V3(dx, dy) * b.BULLET_SPEED
                b.owner = self.id
                b.bulletType = self.favoriteFruit
                if gun == 1: #gun 1 is like jetpack...
                    #b.isVisisble = False
                    b.ttl = 1
                    r = 4.0
                    b.BULLET_SPEED *= -r
                    b.po.m /= r

                game.bullets.append(b)

                #p = mv const.
                #p1 = p2 => m1 v1 = m2 v2 => v1 = (m2 v2) / m1
                #where 1 is the player, 2 is the bullet
                vDiff = -(b.po.m * b.BULLET_SPEED) / self.po.m
                self.po.v += V3(dx, dy) * vDiff
    */
    } //end of updateControls

    public void draw(Game game) {
        //TODO: Draw player sprite to screen
        /*
        x, y = self.po.pos.x, self.po.pos.y

        area = getAreaFromId(self.id, self.w, self.h)
        surface.blit(img["players"], dest=(x, y), area=area)

        //TODO: Draw text above head
        if self.po:
            percentText = "%d%%" % (100.0*(self.po.gravityFactor - 1.0))
        else:
            percentText = "NO BODY"
        percentTextSurface = fnt.render(percentText, False, con.FONT_COLOR)
        surface.blit(percentTextSurface,
                (self.po.pos.x+1, self.po.pos.y - 20))
        */
    }
}
