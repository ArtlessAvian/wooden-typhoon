extends "../Entity.gd"

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

var player;

func _ready():
	if (player == null):
		player = get_node("/root/Floor/Player")

func phys_process_workaround(delta):
	
	move_and_slide((player.global_position - global_position).normalized() * 64)
	
	.phys_process_workaround(delta)

func respond_to_hit(other_entity, damage):
	.respond_to_hit(other_entity, damage)
	if (health <= 0):
		queue_free()

