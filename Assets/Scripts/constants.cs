using UnityEngine;
using System.Collections;

public static class con {
    public static float BULLET_REMOVE_BORDER = 60.0F; //remove bullets when they're this many pixels
                              //outside of a border

    public static float COLLISION_DIST = 35.0F;

    public static int NUM_PLAYER_LIVES = 3;

    public static Color BG_COLOR = new Color(100,100,140);
    public static Color FONT_COLOR = new Color(200, 200, 200);
    public static Color BLACK_HOLE_COLOR = new Color(0, 0, 42);
    public static float BLACK_HOLE_GRAVITY_STRENGTH = 100.0F;
    public static float BLACK_HOLE_START_SIZE = 64.0F;
    public static float EVENT_HORIZON_RADIUS = 180.0F;

    public static float BLACK_HOLE_INCREASE_BY_PLAYER = 2.0F;
    public static float BLACK_HOLE_INCREASE_BY_BULLET = 0.05F;

    public static float GRAVITY_FACTOR_PLAYER_DEFAULT = 1.0F;
    public static float GRAVITY_FACTOR_POWERUP_DEFAULT = 0.2F;
    public static float GRAVITY_FACTOR_PLAYER_INCREASE_PER_HIT = 0.05F;

    /*BLACK = (0,0,0);
    WHITE = (255,255,255);
    GREY = GRAY = (128,128,128);
    RED = (255,0,0);
    GREEN = (0,255,0);
    BLUE = (0,0,255);*/

    public static float BOUNCE_FACTOR_ON_WALLS = -0.9F;

    public static float PLAYER_DRAG = 0.996F;
    public static int START_NUM_PLAYERS = 2;

    public static float POWERUP_PICKUP_DIST = 48;
    public static float POWERUP_SPAWN_DELAY = 6*60;
}
