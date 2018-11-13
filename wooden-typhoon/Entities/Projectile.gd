extends "Entity.gd"

var velocity = Vector2()

func _ready():
	# Called when the node is added to the scene for the first time.
	# Initialization here
	knockback_value = 0
	velocity.x = 100;

func phys_process_workaround(delta):
	move_and_slide(velocity)
	if (get_slide_count() > 0):
		self.queue_free()
#	else:
	.phys_process_workaround(delta)
	if (get_slide_count() > 0):
		self.queue_free()

func do_hitting(other_entity):
	self.queue_free()

func calc_damage(other_entity):
	return 3

func respond_to_hit(other_entity, damage):
	self.queue_free()

func get_type():
	return "Projectile"

################
#   Helpers!   #
################
# Use when instancing
# The idea of returning self is to chain stuff together.

func get_velocity():
	return velocity

func set_position(global_position):
	self.global_position = global_position
	return self

func aim_at(target):
	print(target.global_position.angle_to_point(global_position))
	velocity = velocity.rotated(target.global_position.angle_to_point(global_position))
	return self