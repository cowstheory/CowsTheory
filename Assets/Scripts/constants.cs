using UnityEngine;
using System.Collections;

public static class con {
    public static float BULLET_REMOVE_BORDER = 60.0F; //remove bullets when they're this many pixels
                              //outside of a border

    public static float COLLISION_DIST = 35.0F;

    public static int NUM_PLAYER_LIVES = 3;

	public static Vector3 PLAYER1_SPAWN = new Vector3(-35.0F, 13.0F, 1.0F);
	public static Vector3 PLAYER2_SPAWN = new Vector3(35.0F, -13.0F, 1.0F);

    public static Color FONT_COLOR = new Color(200, 200, 200);
    public static float BLACK_HOLE_GRAVITY_STRENGTH = 100.0F;
    public static float BLACK_HOLE_START_SIZE = 64.0F;
    public static float EVENT_HORIZON_RADIUS = 5.0F;

    public static float BLACK_HOLE_INCREASE_BY_PLAYER = 2.0F;
    public static float BLACK_HOLE_INCREASE_BY_BULLET = 0.05F;

    public static float GRAVITY_FACTOR_PLAYER_DEFAULT = 1.0F;
    public static float GRAVITY_FACTOR_POWERUP_DEFAULT = 0.2F;
    public static float GRAVITY_FACTOR_PLAYER_INCREASE_PER_HIT = 0.05F;

	public static float GRAVITY_COEFFICIENT = 0.15F;
	public static float GRAVITY_EXPONENT = 2.4F;
	
    //multiplier: how much stronger will bullet push other players
    public static float BULLET_COLLISION_MULTIPLIER = 0.4F;

    public static float PLAYER_DRAG = 0.996F;
    public static int START_NUM_PLAYERS = 2;

    //public static float POWERUP_PICKUP_DIST = 48.0F;
    public static float INITIAL_POWERUP_SPAWN_DELAY = 6.0F;
    
    public static float POWERUP_HEALTHPACK_DAMAGE = -0.8F;
	
    public static float CONTROLLER_DEADZONE = 0.2F;
}
