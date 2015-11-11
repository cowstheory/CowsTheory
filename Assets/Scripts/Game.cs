using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour{
	int gameTime;
    // bool exit = false;
    //gravity = V3(con.GRAVITY_X, con.GRAVITY_Y)

    public float blackHoleSize = con.BLACK_HOLE_START_SIZE;

    public List<Player> players;
    public List<Bullet> bullets;

	public List<GameObject> player_objects;

	public GameObject he_man, skeletor;
	//Powerup[] powerup;

    public Game () {
        players = new List<Player>();
        bullets = new List<Bullet>();
    }

	void Start(){
		GameObject p1 = (GameObject)Instantiate(he_man);
		GameObject p2 = (GameObject)Instantiate(skeletor);
		p1.transform.position = new Vector3 (-4,2,0);
		p2.transform.position = new Vector3 (4,2,0);
		player_objects.Add(p1);
		player_objects.Add(p2);
	}

    public void reset() {
		// TODO: Actually reset the game
//        Debug.Log("Game was reset!");
    }

    public void update() {
        gameTime += 1;
        // float dt = 1/60;

        //TODO: oscillate black hole properly
        /*if this.gameTime % 30 == 0: this.blackHoleSize += 1
        elif this.gameTime % 30 == 5: this.blackHoleSize -= 1*/

        /*#Quicker gameplay: continously increase all player's gravityFactor
        #if this.gameTime % 15 == 0:
        #    for player in this.players:
        #        player.po.gravityFactor += 0.01*/
//
//        if (this.gameTime > 1 && this.gameTime % con.POWERUP_SPAWN_DELAY == 0) {
//            Powerup p = new Powerup();
//            p.respawn(this);
//            this.powerups.append(p);
//        }
//

//        foreach (Powerup powerup in this.powerups) {
//            powerup.update(this);
//        }
//
//
//        foreach (Bullet bullet in this.powerups) {
//            bullet.update(this);
//        }

        /* TODO: remove bullets and powerups that are marked for removal
        this.bullets = filter(lambda x: not x.markedForRemoval, this.bullets)
        this.powerups = filter(lambda x: not x.markedForRemoval, this.powerups)*/
		List<Bullet> remaining_bullets = new List<Bullet>();
		foreach (Bullet b in bullets) {
			if(!b.markedForRemoval){
				remaining_bullets.Add(b);
			}
		}
		bullets = remaining_bullets;

        foreach (Player player in players) {
            player.update(this);
        }

        /* TODO: remove players that are out of lives (same as just above this)
        //this.players = filter(lambda x: x.livesLeft > 0, this.players)*/
    }

    public void draw() {
        /*
        for i in range(1,con.BOTTOM_HEIGHT+1) {
            pygame.draw.line(surface, con.GREEN,
                    (0           , this.screenh-i),
                    (this.screenw, this.screenh-i))
        }

        */
//        foreach (Bullet bullet in bullets) {
//            bullet.draw(this);
//        }

        foreach (Player player in players) {
            player.draw(this);
        }

        /* TODO: uncomment when Powerup is done
        foreach (Powerup powerup in this.powerups) {
            powerup.draw(this);
        }*/

        /*
        //TODO: draw black hole
        pygame.draw.circle(surface, con.BLACK_HOLE_COLOR, (self.screenw/2, self.screenh/2),
            int(self.blackHoleSize), 0)
        //TODO: draw event horizon
        pygame.draw.circle(surface, con.BLACK_HOLE_COLOR, (self.screenw/2, self.screenh/2),
            con.EVENT_HORIZON_RADIUS, 1)

        //TODO: visualize number of lives left for each player
        #draw number of lives left
        numPanes = len(self.players)
        paneWidth = self.screenw / float(max(1, numPanes))
        for i, p in enumerate(self.players) {
            for life_index in range(p.livesLeft) {
                headHeight = 16 + 3*(p.id == 0)
                area = player.getAreaFromId(p.id, p.w, p.h)
                area[3] = headHeight

                if len(self.players) < 10:
                    dest = (10 + paneWidth*i + 28*life_index, self.screenh - 40)
                else:
                    dest = (10 + paneWidth*i, self.screenh - 40 - 19 * life_index)

                surface.blit(img["players"],
                    dest=dest,
                    area=area)
            }
        }
        */
    }

    public Vector3 vectorToMiddle(Vector3 otherVec) {
		// TODO: FIX THIS
//        return Vector3(this.screenw/2.0, this.screenh/2.0) - otherVec;
		return new Vector3 ();
    }

//	public ref Player[] getPlayers(){
//		return players;
//	}
}
