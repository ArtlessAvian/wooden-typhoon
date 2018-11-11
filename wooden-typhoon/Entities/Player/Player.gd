extends "../Entity.gd"

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

var weapon = null
var input_vector = Vector2()

func _ready():
	# Called when the node is added to the scene for the first time.
	# Initialization here
	pass

func _physics_process(delta):
	input_vector *= 0;
	if (Input.is_action_pressed("ui_up")):
		input_vector.y -= 1;
	if (Input.is_action_pressed("ui_down")):
		input_vector.y += 1;
	if (Input.is_action_pressed("ui_left")):
		input_vector.x -= 1;
	if (Input.is_action_pressed("ui_right")):
		input_vector.x += 1;
	
	move_and_slide(input_vector * 200)
	
#	$Sprite.frame = input_vector.angle() / PI
#	print($Sprite.frame)