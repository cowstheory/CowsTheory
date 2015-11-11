
public class Game {
    bool exit = False
    gameTime = 0
    //gravity = V3(con.GRAVITY_X, con.GRAVITY_Y)
    
    float blackHoleSize = con.BLACK_HOLE_START_SIZE;
    
    Player[] players;
    //Bullet[] bullets;
    //Powerup[] powerup;
    
    Game () {
        
    }
    
    def reset(self) {
        for player in self.players:
            if player.po:
                player.po.hp = player.po.maxHp
        
        self.__init__()
        print "Game was reset!"
    }
        
    void update() {
        self.gameTime += 1
        self.dt = 1/60.
        
        if self.gameTime % 30 == 0: self.blackHoleSize += 1
        elif self.gameTime % 30 == 5: self.blackHoleSize -= 1
            
        #Quicker gameplay: continously increase all player's gravityFactor
        #if self.gameTime % 15 == 0:
        #    for player in self.players:
        #        player.po.gravityFactor += 0.01
        
        if self.gameTime > 1 and self.gameTime % con.POWERUP_SPAWN_DELAY == 0:
            p = Powerup()
            p.respawn(self)
            self.powerups.append(p)
        
        for powerup in self.powerups:
            powerup.update(self, key)
        
        for bullet in self.bullets:
            bullet.update(self, key)
        
        self.bullets = filter(lambda x: not x.markedForRemoval, self.bullets)
        self.powerups = filter(lambda x: not x.markedForRemoval, self.powerups)
            
        for player in self.players:
            player.update(self, key)
        
        self.players = filter(lambda x: x.livesLeft > 0, self.players)
    }
            
    void draw() {
        for i in range(1,con.BOTTOM_HEIGHT+1) {
            pygame.draw.line(surface, con.GREEN,
                    (0           , self.screenh-i),
                    (self.screenw, self.screenh-i))
        }
        
        for bullet in self.bullets {
            bullet.draw(self, surface, img, fnt)
        }
            
        for p in self.players {
            p.draw(self, surface, img, fnt)
        }
            
        for powerup in self.powerups {
            powerup.draw(self, surface, img, fnt)
        }

        /*
        pygame.draw.circle(surface, con.BLACK_HOLE_COLOR, (self.screenw/2, self.screenh/2),
            int(self.blackHoleSize), 0)
        #draw event horizon
        pygame.draw.circle(surface, con.BLACK_HOLE_COLOR, (self.screenw/2, self.screenh/2),
            con.EVENT_HORIZON_RADIUS, 1)
        
        #draw text
        #percentText = ", ".join(["p%s: %s %%" % \
        #        (player.id + 1, 100*(player.po.gravityFactor - 1.0))
        #        for player in self.players])
        #percentTextSurface = fnt.render(percentText, False, con.FONT_COLOR)
        #surface.blit(percentTextSurface, (5,self.screenh - 40))
        
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

    Vector3 vectorToMiddle(Vector3 otherVec) {
        return Vector3(self.screenw/2.0, self.screenh/2.0) - otherVec;
    }
}
