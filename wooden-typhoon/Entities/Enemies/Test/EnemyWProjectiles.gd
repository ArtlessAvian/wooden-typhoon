extends "../Enemy.gd"

# class member variables go here, for example:
# var a = 2
# var b = "textvar"
var projectile = preload("res://Entities/Enemies/Test/TestProjectile.tscn")

var testtesttesttest = 0;

func _ready():
	._ready()

func phys_process_workaround(delta):
	testtesttesttest += 1
	if (testtesttesttest >= 60):
		var instance = projectile.instance()
		owner.add_child(instance)
		instance.set_position(self.global_position)
		instance.aim_at(player)
		
		testtesttesttest -= 60
	
	.phys_process_workaround(delta)