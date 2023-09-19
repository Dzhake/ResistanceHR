// MeleeHitbox
// Token: 0x06001384 RID: 4996 RVA: 0x0019CA7C File Offset: 0x0019AC7C
public void HitObject(GameObject hitObject, bool fromClient)
{
	InvItem invItem = null;

	try
	{
		invItem = this.myMelee.agent.inventory.equippedWeapon;
	
		if (this.myMelee.agent.inventory.equippedWeapon.itemType == "WeaponProjectile")
			invItem = this.myMelee.agent.inventory.fist;
	}
	catch
	{
	}
	if ((!this.ObjectListContains(hitObject) && this.myMelee.canDamage && this.canHitMore) || fromClient)
	{
		if (this.gc.multiplayerMode && this.gc.serverPlayer && !this.myMelee.agent.localPlayer && !fromClient && this.myMelee.agent.isPlayer != 0)
		{
			bool flag = true;
			if (hitObject.CompareTag("ObjectRealSprite"))
			{
				ObjectReal objectReal;
				if (hitObject.name.Contains("ExtraSprite"))
				{
					objectReal = hitObject.transform.parent.transform.parent.GetComponent<ObjectReal>();
				}
				else
				{
					objectReal = hitObject.GetComponent<ObjectSprite>().objectReal;
				}
				if (objectReal.objectName == "Window")
				{
					Window window = (Window)objectReal;
					if (window.FindDamage(this.myMelee, false, true, fromClient) >= 30)
					{
						this.justHitWindow = true;
					}
					else
					{
						if (window.hitWindowOnce)
						{
							return;
						}
						this.justHitWindow = true;
					}
				}
				if (!objectReal.objectSprite.meshRenderer.enabled || !objectReal.notRealObject || !objectReal.OnFloor || !objectReal.meleeCanPass || !objectReal.tempNoMeleeHits)
				{
					return;
				}
			}
			if (!hitObject.CompareTag("ObjectRealSprite") && !hitObject.CompareTag("AgentSprite") && !hitObject.CompareTag("ItemImage") && !hitObject.CompareTag("Wall"))
			{
				flag = false;
			}
			else if (hitObject.CompareTag("AgentSprite"))
			{
				Agent agent = hitObject.GetComponent<ObjectSprite>().agent;
				if (agent == this.myMelee.agent)
				{
					flag = false;
				}
				if (agent.localPlayer && this.myMelee.agent.isPlayer > 0 && !this.myMelee.agent.localPlayer)
				{
					flag = false;
				}
			}
			if (flag)
			{
				this.FakeHit(hitObject);
				return;
			}
		}
		if (hitObject.CompareTag("MeleeHitbox"))
		{
			if (this.myMelee.agent.statusEffects.hasTrait("BlocksSometimesHit2"))
			{
				if (this.gc.percentChance(60))
				{
					hitObject = hitObject.GetComponent<MeleeColliderBox>().meleeHitbox.myMelee.agent.agentHitboxScript.go;
				}
			}
			else if (this.myMelee.agent.statusEffects.hasTrait("BlocksSometimesHit"))
			{
				if (this.gc.percentChance(30))
				{
					hitObject = hitObject.GetComponent<MeleeColliderBox>().meleeHitbox.myMelee.agent.agentHitboxScript.go;
				}
			}
			else
			{
				Agent agent2 = hitObject.GetComponent<MeleeColliderBox>().meleeHitbox.myMelee.agent;
				if (agent2.statusEffects.hasTrait("BlocksSometimesHit2"))
				{
					if (this.gc.percentChance(60))
					{
						hitObject = this.myMelee.agent.agentHitboxScript.go;
					}
				}
				else if (agent2.statusEffects.hasTrait("BlocksSometimesHit") && this.gc.percentChance(30))
				{
					hitObject = this.myMelee.agent.agentHitboxScript.go;
				}
			}
		}
		if (hitObject.CompareTag("ObjectRealSprite") && !this.myMelee.invItem.meleeNoHit)
		{
			ObjectReal objectReal2;
			if (hitObject.name.Contains("ExtraSprite"))
			{
				objectReal2 = hitObject.transform.parent.transform.parent.GetComponent<ObjectReal>();
			}
			else
			{
				objectReal2 = hitObject.GetComponent<ObjectSprite>().objectReal;
			}
			if (objectReal2.extraSprites.Count > 0)
			{
				for (int i = 0; i < objectReal2.extraSprites.Count; i++)
				{
					this.objectList.Add(objectReal2.extraSprites[i].gameObject);
				}
			}
			else
			{
				this.objectList.Add(hitObject);
			}
			if (!this.gc.serverPlayer && !this.myMelee.agent.localPlayer && this.myMelee.agent.mindControlAgent != this.gc.playerAgent && objectReal2.objectSprite.meshRenderer.enabled && !objectReal2.notRealObject && !objectReal2.OnFloor && !objectReal2.meleeCanPass && !objectReal2.tempNoMeleeHits)
			{
				this.FakeHit(hitObject);
				return;
			}
			if (this.HasLOSMelee(objectReal2) && objectReal2.objectMeshRenderer.enabled)
			{
				bool flag2 = false;
				if (this.myMelee.agent.statusEffects.hasTrait("HitObjectsNoNoise"))
				{
					flag2 = true;
				}
				if (objectReal2.objectName == "Window")
				{
					if (objectReal2.FindDamage(this.myMelee, false, true, fromClient) >= 30)
					{
						this.justHitWindow = true;
					}
					if (flag2)
					{
						Window component = objectReal2.GetComponent<Window>();
						component.StartCoroutine(component.TempNoNoise());
					}
				}
				if (!objectReal2.notRealObject && !objectReal2.OnFloor && (!objectReal2.meleeCanPass || this.justHitWindow) && !objectReal2.tempNoMeleeHits)
				{
					objectReal2.Damage(this.myMelee, fromClient);
					if (!objectReal2.noDamageNoise && !this.myMelee.successfullySleepKilled && !flag2)
					{
						this.gc.spawnerMain.SpawnNoise(objectReal2.FindDamageNoisePos(objectReal2.tr.position), (float)objectReal2.noiseHitVol, null, null, this.myMelee.agent);
					}
					if (this.myMelee.agent != null && this.gc.serverPlayer)
					{
						this.gc.OwnCheck(this.myMelee.agent, hitObject, "Normal", 1);
					}
					if (this.justHitWindow)
					{
						this.justHitWindow = false;
					}
					if (this.myMelee.hitParticlesTr != null && this.myMelee.meleeContainerTr != null)
					{
						this.gc.spawnerMain.SpawnParticleEffect("ObjectDestroyed", this.myMelee.hitParticlesTr.position, this.myMelee.meleeContainerTr.eulerAngles.z - 90f);
					}
					if (objectReal2.destroying || objectReal2.justDamaged)
					{
						if (this.myMelee.agent.isPlayer > 0 && this.myMelee.agent.localPlayer && !objectReal2.noDestroyEffects)
						{
							this.gc.ScreenShake(0.2f, 80f, this.myMelee.agent.tr.position, this.myMelee.agent);
							this.gc.FreezeFrames(1);
						}
					}
					else if (this.myMelee.agent.isPlayer > 0 && this.myMelee.agent.localPlayer)
					{
						this.gc.ScreenShake(0.1f, 80f, this.myMelee.agent.tr.position, this.myMelee.agent);
						this.gc.FreezeFrames(0);
					}
					this.gc.alienFX.HitObject(this.myMelee.agent);
					this.MeleeHitEffect(hitObject);
					this.gc.playerControl.Vibrate(this.myMelee.agent.isPlayer, Mathf.Clamp((float)objectReal2.damagedAmount / 100f + 0.05f, 0f, 0.25f), Mathf.Clamp((float)objectReal2.damagedAmount / 132f + 0.05f, 0f, 0.2f));
					if (!this.gc.serverPlayer && (this.myMelee.agent.isPlayer > 0 || this.myMelee.agent.mindControlAgent == this.gc.playerAgent))
					{
						if (this.myMelee.agent.isPlayer != 0)
						{
							this.myMelee.agent.objectMult.CallCmdMeleeHitObjectReal(objectReal2.objectNetID);
							return;
						}
						this.gc.playerAgent.objectMult.CallCmdMeleeHitObjectRealNPC(this.myMelee.agent.objectNetID, objectReal2.objectNetID);
						return;
					}
					else if (this.gc.serverPlayer && this.gc.multiplayerMode)
					{
						this.myMelee.agent.objectMult.CallRpcMeleeHitObjectFake(objectReal2.objectNetID);
						return;
					}
				}
			}
		}
		else if (hitObject.CompareTag("AgentSprite"))
		{
			this.objectList.Add(hitObject);
			Agent agent3 = hitObject.GetComponent<ObjectSprite>().agent;
			if (this.gc.multiplayerMode)
			{
				if (this.gc.serverPlayer && this.myMelee.agent.localPlayer && agent3.isPlayer > 0 && !agent3.localPlayer)
				{
					this.FakeHit(hitObject);
					return;
				}
				if (this.gc.serverPlayer && this.myMelee.agent.isPlayer == 0 && agent3.isPlayer > 0 && !agent3.localPlayer)
				{
					this.FakeHit(hitObject);
					return;
				}
				if (this.gc.multiplayerMode && this.gc.serverPlayer && this.myMelee.agent.isPlayer == 0 && agent3.isPlayer == 0 && this.myMelee.agent.mindControlAgent != null && this.myMelee.agent.mindControlAgent != this.gc.playerAgent && !agent3.dead)
				{
					this.FakeHit(hitObject);
					return;
				}
				if (this.gc.multiplayerMode && this.gc.serverPlayer && this.myMelee.agent.isPlayer == 0 && agent3.isPlayer == 0 && agent3.mindControlAgent != null && agent3.mindControlAgent != this.gc.playerAgent && !agent3.dead)
				{
					this.FakeHit(hitObject);
					return;
				}
				if (!this.gc.serverPlayer && this.myMelee.agent.isPlayer == 0 && !agent3.localPlayer && this.myMelee.agent != agent3 && ((this.myMelee.agent.mindControlAgent != this.gc.playerAgent && agent3.mindControlAgent != this.gc.playerAgent) || agent3.dead))
				{
					this.FakeHit(hitObject);
					return;
				}
				if (!this.gc.serverPlayer && this.myMelee.agent.isPlayer > 0 && !this.myMelee.agent.localPlayer && !agent3.localPlayer)
				{
					this.FakeHit(hitObject);
					return;
				}
				if (!this.gc.serverPlayer && (this.myMelee.agent.localPlayer || this.myMelee.agent.mindControlAgent == this.gc.playerAgent) && agent3.isPlayer > 0 && !agent3.localPlayer)
				{
					this.FakeHit(hitObject);
					return;
				}
				if (!this.gc.serverPlayer && this.myMelee.agent.isPlayer != 0 && !this.myMelee.agent.localPlayer && agent3.isPlayer != 0 && !agent3.localPlayer)
				{
					this.FakeHit(hitObject);
					return;
				}
			}
			if (this.myMelee.agent != agent3 && !agent3.ghost && !agent3.fellInHole && !this.gc.cinematic && this.HasLOSMelee(agent3))
			{
				this.objectList.Add(agent3.melee.meleeHitbox.gameObject);
				if (this.myMelee.invItem.meleeNoHit && !agent3.dead)
				{
					Relationship relationship = agent3.relationships.GetRelationship(this.myMelee.agent);
					if (!agent3.movement.HasLOSObjectBehind(this.myMelee.agent) || agent3.sleeping || this.myMelee.agent.isPlayer == 0 || this.myMelee.agent.invisible || (this.myMelee.invItem.invItemName == "StealingGlove" && this.myMelee.agent.oma.superSpecialAbility))
					{
						this.canHitMore = false;
						if (this.myMelee.invItem.invItemName == "ChloroformHankie")
						{
							if (!fromClient)
							{
								this.HitAftermath(hitObject, fromClient, agent3, this.myMelee.invItem.invItemName);
							}
						}
						else if (this.myMelee.invItem.invItemName == "StealingGlove")
						{
							if (this.myMelee.agent.oma.superSpecialAbility)
							{
								this.HitAftermath(hitObject, fromClient, agent3, this.myMelee.invItem.invItemName);
							}
							else if (this.myMelee.agent.movement.HasLOSObject(agent3, "360", false, true))
							{
								agent3.agentHelperTr.localPosition = new Vector3(-0.64f, 0f, 0f);
								if ((!this.gc.tileInfo.IsOverlapping(agent3.agentHelperTr.position, "Wall") || agent3.sleeping) && !fromClient)
								{
									this.HitAftermath(hitObject, fromClient, agent3, this.myMelee.invItem.invItemName);
								}
							}
						}
					}
					else
					{
						if (this.myMelee.invItem.invItemName == "StealingGlove" && relationship.relType != "Aligned" && relationship.relType != "Submissive" && this.myMelee.agent.movement.HasLOSObject(agent3, "360", false, true) && !fromClient)
						{
							this.HitAftermath(hitObject, fromClient, agent3, "StealingGloveFail");
						}
						if (this.gc.serverPlayer)
						{
							this.gc.spawnerMain.SpawnNoise(this.myMelee.agent.tr.position, 0f, null, null, this.myMelee.agent);
						}
					}
					if ((this.myMelee.invItem.invItemName == "ChloroformHankie" || this.myMelee.invItem.invItemName == "Handcuffs") && relationship.relType != "Aligned" && relationship.relType != "Submissive" && !fromClient)
					{
						this.HitAftermath(hitObject, fromClient, agent3, "ChloroformHankieFail");
					}
				}
				bool flag3 = !this.myMelee.invItem.meleeNoHit && this.myMelee.agent.DontHitAlignedCheck(agent3);
				if (flag3)
				{
					agent3.melee.meleeHitbox.objectList.Add(base.gameObject);
					agent3.melee.meleeHitbox.objectList.Add(this.myMelee.agent.sprTr.gameObject);
					if (this.myMelee.agent.zombified && agent3.isPlayer == 0 && !agent3.oma.bodyGuarded)
					{
						agent3.zombieWhenDead = true;
					}
					if (agent3.isPlayer == 0 && this.myMelee.agent.isPlayer != 0 && !agent3.dead && agent3.agentName != "Zombie" && !agent3.inhuman && !agent3.mechEmpty && !agent3.mechFilled && this.myMelee.agent.localPlayer && !agent3.statusEffects.hasStatusEffect("Invincible"))
					{
						if (this.myMelee.agent.statusEffects.hasTrait("FleshFeast2"))
						{
							this.myMelee.agent.statusEffects.ChangeHealth(6f);
						}
						else if (this.myMelee.agent.statusEffects.hasTrait("FleshFeast"))
						{
							this.myMelee.agent.statusEffects.ChangeHealth(3f);
						}
					}
					if (this.gc.serverPlayer || agent3.health > 0f || agent3.dead)
					{
						agent3.Damage(this.myMelee, fromClient);
					}
					this.myMelee.agent.relationships.FollowerAlert(agent3);
					if (agent3.statusEffects.hasTrait("AttacksDamageAttacker2") && !this.myMelee.agent.ghost)
					{
						int myChance = agent3.DetermineLuck(20, "AttacksDamageAttacker", true);
						if (this.gc.percentChance(myChance))
						{
							this.myMelee.agent.lastHitByAgent = agent3;
							this.myMelee.agent.justHitByAgent2 = agent3;
							this.myMelee.agent.lastHitByAgent = agent3;
							this.myMelee.agent.deathMethod = "AttacksDamageAttacker";
							this.myMelee.agent.deathKiller = agent3.agentName;
							this.myMelee.agent.statusEffects.ChangeHealth(-10f);
						}
					}
					else if (agent3.statusEffects.hasTrait("AttacksDamageAttacker") && !this.myMelee.agent.ghost)
					{
						int myChance2 = agent3.DetermineLuck(20, "AttacksDamageAttacker", true);
						if (this.gc.percentChance(myChance2))
						{
							this.myMelee.agent.lastHitByAgent = agent3;
							this.myMelee.agent.justHitByAgent2 = agent3;
							this.myMelee.agent.lastHitByAgent = agent3;
							this.myMelee.agent.deathMethod = "AttacksDamageAttacker";
							this.myMelee.agent.deathKiller = agent3.agentName;
							this.myMelee.agent.statusEffects.ChangeHealth(-5f);
						}
					}
					if (agent3.justDied && this.myMelee.agent.isPlayer > 0 && !this.gc.coopMode && !this.gc.fourPlayerMode && !this.gc.multiplayerMode && this.gc.sessionDataBig.slowMotionCinematic && this.gc.percentChance(25))
					{
						if (this.gc.challenges.Contains("LowHealth"))
						{
							if (this.gc.percentChance(50))
							{
								this.gc.StartCoroutine(this.gc.SetSecondaryTimeScale(0.1f, 0.13f));
							}
						}
						else
						{
							this.gc.StartCoroutine(this.gc.SetSecondaryTimeScale(0.1f, 0.13f));
						}
					}
					float num = 0f;
					if (this.myMelee.successfullySleepKilled || this.myMelee.successfullyBackstabbed)
					{
						num = 0f;
					}
					else if ((!agent3.dead || agent3.justDied) && !agent3.disappeared)
					{
						num = (float)Mathf.Clamp(agent3.damagedAmount * 20, 80, 9999);
					}
					else if (!agent3.disappeared)
					{
						num = 80f;
					}
					if (this.myMelee.agent.statusEffects.hasTrait("CauseBiggerKnockback"))
					{
						num *= 2f;
					}
					Vector3 position = agent3.tr.position;
					Vector2 velocity = agent3.rb.velocity;
					if (!agent3.disappeared && !fromClient)
					{
						agent3.movement.KnockBackBullet(this.myMelee.meleeContainerTr.gameObject, num, true, this.myMelee.agent);
					}
					bool flag4 = false;
					if (agent3.hasEmployer && agent3.employer.statusEffects.hasSpecialAbility("ProtectiveShell") && agent3.employer.objectMult.chargingSpecialLunge)
					{
						flag4 = true;
					}
					if (agent3.statusEffects.hasSpecialAbility("ProtectiveShell") && agent3.objectMult.chargingSpecialLunge)
					{
						flag4 = true;
					}
					if (flag4)
					{
						bool flag5 = true;
						if (this.gc.multiplayerMode && this.gc.serverPlayer)
						{
							if (agent3.isPlayer != 0 && !agent3.localPlayer && this.myMelee.agent.isPlayer == 0)
							{
								flag5 = false;
							}
							if (this.myMelee.agent.isPlayer != 0 && !this.myMelee.agent.localPlayer && agent3.isPlayer == 0)
							{
								flag5 = false;
							}
						}
						if (flag5)
						{
							this.myMelee.agent.movement.KnockBackBullet(agent3.gameObject, 240f, true, agent3);
							if (this.gc.serverPlayer && this.myMelee.agent.isPlayer == 0 && invItem.invItemName != "Fist" && !agent3.warZoneAgent)
							{
								int myChance3 = agent3.DetermineLuck(15, "ChanceToKnockWeapons", true);
								if (this.gc.percentChance(myChance3))
								{
									InvItem invItem2 = this.myMelee.agent.inventory.FindItem(invItem.invItemName);
									this.myMelee.agent.inventory.DestroyItem(invItem2);
									this.gc.spawnerMain.SpillItem(this.tr.position, invItem2);
									this.gc.spawnerMain.SpawnStatusText(this.myMelee.agent, "OutOfAmmo", invItem2.invItemName, "Item");
									if (!this.gc.serverPlayer && (this.myMelee.agent.isPlayer != 0 || this.myMelee.agent.mindControlAgent == this.gc.playerAgent))
									{
										this.myMelee.agent.objectMultPlayfield.SpawnStatusText("OutOfAmmo", invItem2.invItemName, "Item", this.myMelee.agent.objectNetID, "", "");
									}
									this.myMelee.agent.statusEffects.CreateBuffText("DroppedWeapon", this.myMelee.agent.objectNetID);
									this.myMelee.agent.dontPickUpWeapons = true;
								}
							}
						}
					}
					if (!this.gc.serverPlayer && (this.myMelee.agent.localPlayer || this.myMelee.agent.mindControlAgent == this.gc.playerAgent))
					{
						this.myMelee.agent.objectMultPlayfield.TempDisableNetworkTransform(agent3);
						Quaternion localRotation = this.myMelee.meleeHelperTr.localRotation;
						this.myMelee.meleeHelperTr.rotation = this.myMelee.meleeContainerTr.rotation;
						this.myMelee.meleeHelperTr.position = this.myMelee.meleeContainerTr.position;
						this.myMelee.meleeHelperTr.localPosition = new Vector3(this.myMelee.meleeHelperTr.localPosition.x, this.myMelee.meleeHelperTr.localPosition.y + 10f, this.myMelee.meleeHelperTr.localPosition.z);
						Vector3 position2 = this.myMelee.meleeHelperTr.position;
						this.myMelee.meleeHelperTr.localPosition = Vector3.zero;
						this.myMelee.meleeHelperTr.localRotation = localRotation;
						if (!this.myMelee.agent.testingNewClientLerps)
						{
							if (this.myMelee.agent.isPlayer != 0)
							{
								this.myMelee.agent.objectMult.CallCmdMeleeHitAgent(agent3.objectNetID, position2, (int)num, position, agent3.rb.velocity);
							}
							else
							{
								this.gc.playerAgent.objectMult.CallCmdMeleeHitAgentNPC(this.myMelee.agent.objectNetID, agent3.objectNetID, position2, (int)num, position, agent3.rb.velocity);
							}
						}
					}
					else if (this.gc.multiplayerMode && this.gc.serverPlayer)
					{
						this.myMelee.agent.objectMult.CallRpcMeleeHitObjectFake(agent3.objectNetID);
					}
					if ((this.myMelee.agent.isPlayer > 0 && this.myMelee.agent.localPlayer) || (agent3.isPlayer > 0 && agent3.localPlayer))
					{
						if (agent3.justDied)
						{
							this.gc.ScreenShake(0.25f, (float)Mathf.Clamp(15 * agent3.damagedAmount, 160, 500), Vector2.zero, this.myMelee.agent);
						}
						else
						{
							this.gc.ScreenShake(0.2f, (float)Mathf.Clamp(15 * agent3.damagedAmount, 0, 500), Vector2.zero, this.myMelee.agent);
						}
					}
					this.gc.alienFX.PlayerHitEnemy(this.myMelee.agent);
					this.myMelee.agent.combat.meleeJustHitCooldown = this.myMelee.agent.combat.meleeJustHitTimeStart;
					this.myMelee.agent.combat.meleeJustHitCloseCooldown = this.myMelee.agent.combat.meleeJustHitCloseTimeStart;
					if (this.gc.serverPlayer)
					{
						if (this.myMelee.successfullyBackstabbed)
						{
							this.gc.spawnerMain.SpawnNoise(this.tr.position, 0.7f, null, null, this.myMelee.agent);
						}
						else if (!this.myMelee.successfullySleepKilled)
						{
							this.gc.spawnerMain.SpawnNoise(this.tr.position, 1f, null, null, this.myMelee.agent);
						}
					}
					this.MeleeHitEffect(hitObject);
					this.gc.playerControl.Vibrate(this.myMelee.agent.isPlayer, Mathf.Clamp((float)agent3.damagedAmount / 100f + 0.05f, 0f, 0.25f), Mathf.Clamp((float)agent3.damagedAmount / 132f + 0.05f, 0f, 0.2f));
					if (this.gc.levelType == "Tutorial")
					{
						this.gc.tutorial.MeleeTarget(agent3);
						return;
					}
				}
			}
		}
		else if (hitObject.CompareTag("ItemImage"))
		{
			this.objectList.Add(hitObject);
			Item component2 = hitObject.transform.parent.GetComponent<Item>();
			if (!this.gc.serverPlayer && !this.myMelee.agent.localPlayer && this.myMelee.agent.mindControlAgent != this.gc.playerAgent)
			{
				this.FakeHit(hitObject);
				return;
			}
			if (!component2.justSpilled && !this.myMelee.invItem.meleeNoHit && component2.itemObject == null && this.HasLOSMelee(component2))
			{
				Vector3 position3 = component2.tr.position;
				if (!fromClient)
				{
					component2.movement.KnockBackBullet(this.myMelee.meleeContainerTr.gameObject, 250f, true, this.myMelee.agent);
				}
				component2.Damage(this.myMelee, fromClient);
				if (component2.invItem.reactOnTouch)
				{
					component2.TouchMe(this.myMelee.agent, "MeleeHitbox");
				}
				component2.thrower = this.myMelee.agent;
				if (component2.go.activeSelf)
				{
					component2.StartCoroutine(component2.HitCauserCoroutine(this.myMelee.agent));
				}
				if (this.gc.serverPlayer && !this.myMelee.successfullySleepKilled && !this.myMelee.agent.statusEffects.hasTrait("HitObjectsNoNoise"))
				{
					this.gc.spawnerMain.SpawnNoise(this.tr.position, 1f, null, null, this.myMelee.agent);
				}
				if (component2.startingOwner != 0 && this.gc.serverPlayer && !this.myMelee.agent.statusEffects.hasTrait("NoStealPenalty"))
				{
					this.gc.OwnCheck(this.myMelee.agent, hitObject.transform.parent.gameObject, "Normal", 1);
				}
				Physics2D.IgnoreCollision(component2.myCollider2D, this.myMelee.agent.myCollider2D, true);
				Physics2D.IgnoreCollision(component2.myCollider2D, this.myMelee.agent.agentItemCollider, true);
				this.MeleeHitEffect(hitObject);
				this.gc.playerControl.Vibrate(this.myMelee.agent.isPlayer, Mathf.Clamp((float)this.myMelee.invItem.meleeDamage / 100f + 0.05f, 0f, 0.25f), Mathf.Clamp((float)this.myMelee.invItem.meleeDamage / 132f + 0.05f, 0f, 0.2f));
				if (!this.gc.serverPlayer && (this.myMelee.agent.localPlayer || this.myMelee.agent.mindControlAgent == this.gc.playerAgent))
				{
					this.myMelee.agent.objectMultPlayfield.TempDisableNetworkTransform(component2);
					Quaternion localRotation2 = this.myMelee.meleeHelperTr.localRotation;
					this.myMelee.meleeHelperTr.rotation = this.myMelee.meleeContainerTr.rotation;
					this.myMelee.meleeHelperTr.position = this.myMelee.meleeContainerTr.position;
					this.myMelee.meleeHelperTr.localPosition = new Vector3(this.myMelee.meleeHelperTr.localPosition.x, this.myMelee.meleeHelperTr.localPosition.y + 10f, this.myMelee.meleeHelperTr.localPosition.z);
					Vector3 position4 = this.myMelee.meleeHelperTr.position;
					this.myMelee.meleeHelperTr.localPosition = Vector3.zero;
					this.myMelee.meleeHelperTr.localRotation = localRotation2;
					if (this.myMelee.agent.isPlayer != 0)
					{
						this.myMelee.agent.objectMult.CallCmdMeleeHitItem(component2.objectNetID, position4, 250, position3, component2.rb.velocity);
						return;
					}
					this.gc.playerAgent.objectMult.CallCmdMeleeHitItemNPC(this.myMelee.agent.objectNetID, component2.objectNetID, position4, 250, position3, component2.rb.velocity);
					return;
				}
				else if (this.gc.multiplayerMode)
				{
					bool serverPlayer = this.gc.serverPlayer;
					return;
				}
			}
		}
		else if (hitObject.CompareTag("MeleeHitbox"))
		{
			Melee melee = hitObject.GetComponent<MeleeColliderBox>().meleeHitbox.myMelee;
			this.objectList.Add(melee.meleeHitbox.gameObject);
			if (this.myMelee.invItem.invItemName == "StealingGlove" || this.myMelee.invItem.invItemName == "ChloroformHankie")
			{
				return;
			}
			if (melee.invItem.invItemName == "StealingGlove" || melee.invItem.invItemName == "ChloroformHankie")
			{
				return;
			}
			Agent agent4 = hitObject.GetComponent<MeleeColliderBox>().meleeHitbox.myMelee.agent;
			if (this.gc.serverPlayer && this.myMelee.agent.isPlayer == 0 && agent4.isPlayer > 0 && !agent4.localPlayer)
			{
				return;
			}
			if (!this.gc.serverPlayer && this.myMelee.agent.isPlayer == 0 && !agent4.localPlayer && this.myMelee.agent != agent4 && ((agent4.mindControlAgent != this.gc.playerAgent && this.myMelee.agent.mindControlAgent != this.gc.playerAgent) || agent4.dead))
			{
				return;
			}
			if (this.gc.multiplayerMode && this.gc.serverPlayer && this.myMelee.agent.isPlayer == 0 && agent4.isPlayer == 0 && this.myMelee.agent.mindControlAgent != null && this.myMelee.agent.mindControlAgent != this.gc.playerAgent && !agent4.dead)
			{
				this.FakeHit(hitObject);
				return;
			}
			if (this.gc.multiplayerMode && this.gc.serverPlayer && this.myMelee.agent.isPlayer == 0 && agent4.isPlayer == 0 && agent4.mindControlAgent != null && agent4.mindControlAgent != this.gc.playerAgent && !agent4.dead)
			{
				this.FakeHit(hitObject);
				return;
			}
			if (!this.gc.serverPlayer && this.myMelee.agent.isPlayer > 0 && !this.myMelee.agent.localPlayer && !agent4.localPlayer)
			{
				return;
			}
			if (!this.myMelee.agent.DontHitAlignedCheck(agent4))
			{
				return;
			}
			if (this.myMelee.agent != agent4 && this.myMelee.agent.agentSpriteTransform.localScale.x != 3f && agent4.agentSpriteTransform.localScale.x != 3f && this.myMelee.agent.agentSpriteTransform.localScale.x > 0.34f && agent4.agentSpriteTransform.localScale.x > 0.34f && !this.myMelee.invItem.meleeNoHit && this.HasLOSMelee(melee.agent))
			{
				melee.meleeHitbox.objectList.Add(base.gameObject);
				this.objectList.Add(agent4.sprTr.gameObject);
				melee.meleeHitbox.objectList.Add(this.myMelee.agent.sprTr.gameObject);
				int num2 = this.myMelee.agent.FindDamageTestOnly(hitObject.GetComponent<MeleeColliderBox>().meleeHitbox.myMelee);
				int num3 = agent4.FindDamageTestOnly(this.myMelee);
				int num4 = 0;
				int num5;
				if (melee.specialLunge)
				{
					num5 = Mathf.Clamp(300, 100, 200);
				}
				else
				{
					num5 = Mathf.Clamp(num2 * 10, 100, 200);
				}
				if (this.myMelee.specialLunge && !fromClient)
				{
					num4 = Mathf.Clamp(300, 100, 200);
				}
				else if (!fromClient)
				{
					num4 = Mathf.Clamp(num3 * 10, 100, 200);
				}
				Vector3 position5 = agent4.tr.position;
				bool flag6 = true;
				if (this.gc.multiplayerMode && this.gc.serverPlayer)
				{
					if (agent4.isPlayer != 0 && !agent4.localPlayer && this.myMelee.agent.isPlayer == 0)
					{
						flag6 = false;
					}
					if (this.myMelee.agent.isPlayer != 0 && !this.myMelee.agent.localPlayer && agent4.isPlayer == 0)
					{
						flag6 = false;
					}
				}
				if (flag6)
				{
					this.myMelee.agent.movement.KnockBackBullet(melee.meleeContainerTr.gameObject, (float)num5, true, melee.agent);
					if (!fromClient)
					{
						agent4.movement.KnockBackBullet(this.myMelee.meleeContainerTr.gameObject, (float)num4, true, this.myMelee.agent);
					}
				}
				if (!this.gc.serverPlayer)
				{
					Agent agent5 = null;
					Agent agent6 = null;
					if (this.myMelee.agent.localPlayer || this.myMelee.agent.mindControlAgent == this.gc.playerAgent)
					{
						agent5 = this.myMelee.agent;
						agent6 = agent4;
					}
					else if (agent4.localPlayer || agent4.mindControlAgent == this.gc.playerAgent)
					{
						agent5 = agent4;
						agent6 = this.myMelee.agent;
					}
					if (agent5 != null)
					{
						agent5.objectMultPlayfield.TempDisableNetworkTransform(agent6);
						Quaternion localRotation3 = agent5.melee.meleeHelperTr.localRotation;
						agent5.melee.meleeHelperTr.rotation = agent5.melee.meleeContainerTr.rotation;
						agent5.melee.meleeHelperTr.position = agent5.melee.meleeContainerTr.position;
						agent5.melee.meleeHelperTr.localPosition = new Vector3(agent5.melee.meleeHelperTr.localPosition.x, agent5.melee.meleeHelperTr.localPosition.y + 10f, agent5.melee.meleeHelperTr.localPosition.z);
						Vector3 position6 = agent5.melee.meleeHelperTr.position;
						string str = "MeleeHitMelee KnockToPosition: ";
						Vector3 vector = position6;
						string str2 = vector.ToString();
						string str3 = " - ";
						vector = position5;
						Debug.Log(str + str2 + str3 + vector.ToString());
						agent5.melee.meleeHelperTr.localPosition = Vector3.zero;
						agent5.melee.meleeHelperTr.localRotation = localRotation3;
						if (agent5.isPlayer != 0)
						{
							agent5.objectMult.CallCmdMeleeHitMelee(agent6.objectNetID, position6, num5, position5, agent6.rb.velocity);
						}
						else
						{
							this.gc.playerAgent.objectMult.CallCmdMeleeHitMeleeNPC(agent5.objectNetID, agent6.objectNetID, position6, num5, position5, agent6.rb.velocity);
						}
					}
				}
				else if (this.gc.multiplayerMode && this.gc.serverPlayer)
				{
					this.myMelee.agent.objectMult.CallRpcMeleeHitObjectFake(agent4.objectNetID);
				}
				if (!this.myMelee.agent.ghost && !agent4.ghost)
				{
					if (invItem.invItemName != "Fist" && agent4.inventory.equippedWeapon.invItemName == "Fist")
					{
						agent4.lastHitByAgent = this.myMelee.agent;
						agent4.justHitByAgent2 = this.myMelee.agent;
						agent4.lastHitByAgent = this.myMelee.agent;
						agent4.deathMethodItem = invItem.invItemName;
						agent4.deathMethodObject = invItem.invItemName;
						agent4.deathMethod = invItem.invItemName;
						agent4.deathKiller = this.myMelee.agent.agentName;
						if (!this.gc.serverPlayer || this.myMelee.agent.localPlayer || this.myMelee.agent.isPlayer == 0)
						{
							if (this.myMelee.agent.zombified && agent4.isPlayer == 0 && !agent4.oma.bodyGuarded)
							{
								agent4.zombieWhenDead = true;
							}
							agent4.statusEffects.ChangeHealth(-1f);
						}
					}
					else if (invItem.invItemName == "Fist" && agent4.inventory.equippedWeapon.invItemName != "Fist")
					{
						this.myMelee.agent.lastHitByAgent = agent4;
						this.myMelee.agent.justHitByAgent2 = agent4;
						this.myMelee.agent.lastHitByAgent = agent4;
						agent4.deathMethodItem = invItem.invItemName;
						agent4.deathMethodObject = invItem.invItemName;
						this.myMelee.agent.deathMethod = agent4.inventory.equippedWeapon.invItemName;
						this.myMelee.agent.deathKiller = agent4.agentName;
						if (!this.gc.serverPlayer || this.myMelee.agent.localPlayer || this.myMelee.agent.isPlayer == 0)
						{
							if (agent4.zombified && this.myMelee.agent.isPlayer == 0 && !this.myMelee.agent.oma.bodyGuarded)
							{
								this.myMelee.agent.zombieWhenDead = true;
							}
							this.myMelee.agent.statusEffects.ChangeHealth(-1f);
						}
					}
				}
				this.myMelee.agent.inventory.DepleteMelee(5);
				agent4.inventory.DepleteMelee(5);
				this.MeleeHitEffect(hitObject);
				if ((this.myMelee.agent.isPlayer > 0 && this.myMelee.agent.localPlayer) || (melee.agent.isPlayer > 0 && melee.agent.localPlayer))
				{
					this.gc.ScreenShake(0.2f, 80f, this.myMelee.agent.tr.position, this.myMelee.agent);
					this.gc.FreezeFrames(1);
				}
				this.gc.alienFX.BlockAttack(this.myMelee.agent);
				this.gc.alienFX.BlockAttack(melee.agent);
				if (!this.myMelee.agent.killerRobot && !melee.agent.killerRobot)
				{
					this.gc.EnforcerAlertAttack(this.myMelee.agent, melee.agent, 7.4f);
					this.gc.EnforcerAlertAttack(melee.agent, this.myMelee.agent, 7.4f);
				}
				this.gc.playerControl.Vibrate(this.myMelee.agent.isPlayer, Mathf.Clamp((float)this.myMelee.invItem.meleeDamage / 100f + 0.05f, 0f, 0.25f), Mathf.Clamp((float)this.myMelee.invItem.meleeDamage / 132f + 0.05f, 0f, 0.2f));
				this.myMelee.agent.combat.meleeJustBlockedCooldown = this.myMelee.agent.combat.meleeJustBlockedTimeStart;
				agent4.combat.meleeJustBlockedCooldown = agent4.combat.meleeJustBlockedTimeStart;
				if (this.gc.serverPlayer)
				{
					this.gc.spawnerMain.SpawnNoise(this.tr.position, 1f, null, null, this.myMelee.agent);
				}
				if (this.myMelee.hitParticlesTr != null && this.myMelee.meleeContainerTr != null)
				{
					this.gc.spawnerMain.SpawnParticleEffect("ObjectDestroyed", this.myMelee.hitParticlesTr.position, this.myMelee.meleeContainerTr.eulerAngles.z - 90f);
				}
				if ((this.myMelee.agent.statusEffects.hasTrait("ChanceToKnockWeapons") || this.myMelee.agent.statusEffects.hasTrait("KnockWeapons")) && this.gc.serverPlayer && agent4.isPlayer == 0 && agent4.inventory.equippedWeapon.invItemName != "Fist" && !agent4.warZoneAgent)
				{
					int myChance4 = 15;
					bool flag7 = this.myMelee.agent.statusEffects.hasTrait("KnockWeapons");
					if (!flag7)
					{
						myChance4 = this.myMelee.agent.DetermineLuck(15, "ChanceToKnockWeapons", true);
					}
					if (this.gc.percentChance(myChance4) || flag7)
					{
						InvItem invItem3 = agent4.inventory.FindItem(agent4.inventory.equippedWeapon.invItemName);
						agent4.inventory.DestroyItem(invItem3);
						this.gc.spawnerMain.SpillItem(this.tr.position, invItem3);
						this.gc.spawnerMain.SpawnStatusText(agent4, "OutOfAmmo", invItem3.invItemName, "Item");
						if (!this.gc.serverPlayer)
						{
							agent4.objectMultPlayfield.SpawnStatusText("OutOfAmmo", invItem3.invItemName, "Item", this.myMelee.agent.objectNetID, "", "");
						}
						agent4.statusEffects.CreateBuffText("DroppedWeapon");
						agent4.dontPickUpWeapons = true;
					}
				}
				if ((agent4.statusEffects.hasTrait("ChanceToKnockWeapons") || agent4.statusEffects.hasTrait("KnockWeapons")) && this.gc.serverPlayer && this.myMelee.agent.isPlayer == 0 && invItem.invItemName != "Fist" && !agent4.warZoneAgent)
				{
					int myChance5 = 15;
					if (!agent4.statusEffects.hasTrait("KnockWeapons"))
					{
						myChance5 = agent4.DetermineLuck(15, "ChanceToKnockWeapons", true);
					}
					if (this.gc.percentChance(myChance5) || agent4.statusEffects.hasTrait("KnockWeapons"))
					{
						InvItem invItem4 = this.myMelee.agent.inventory.FindItem(invItem.invItemName);
						this.myMelee.agent.inventory.DestroyItem(invItem4);
						this.gc.spawnerMain.SpillItem(this.tr.position, invItem4);
						this.gc.spawnerMain.SpawnStatusText(this.myMelee.agent, "OutOfAmmo", invItem4.invItemName, "Item");
						if (!this.gc.serverPlayer && (this.myMelee.agent.isPlayer != 0 || this.myMelee.agent.mindControlAgent == this.gc.playerAgent))
						{
							this.myMelee.agent.objectMultPlayfield.SpawnStatusText("OutOfAmmo", invItem4.invItemName, "Item", this.myMelee.agent.objectNetID, "", "");
						}
						this.myMelee.agent.statusEffects.CreateBuffText("DroppedWeapon", this.myMelee.agent.objectNetID);
						this.myMelee.agent.dontPickUpWeapons = true;
						return;
					}
				}
			}
		}
		else if (hitObject.CompareTag("BulletHitbox"))
		{
			this.objectList.Add(hitObject);
			if (this.myMelee.agent.isPlayer > 0)
			{
				bool localPlayer = this.myMelee.agent.localPlayer;
				return;
			}
		}
		else if (hitObject.CompareTag("Wall"))
		{
			this.objectList.Add(hitObject);
			if (!this.hitWall && !this.myMelee.invItem.meleeNoHit)
			{
				this.hitWall = true;
				bool flag8 = false;
				int num6 = this.myMelee.agent.FindDamage(this.myMelee, true, fromClient);
				if (this.myMelee.agent.agentSpriteTransform.localScale.x > 1f)
				{
					num6 = 200;
					TileData tileData = this.gc.tileInfo.GetTileData(hitObject.transform.position);
					if (tileData.wallMaterial != wallMaterialType.Steel && tileData.wallMaterial != wallMaterialType.Glass)
					{
						this.hitWall = false;
					}
					if (this.hitWall2 == 0)
					{
						this.hitWall2 = 1;
					}
				}
				bool streamingWorld = this.gc.streamingWorld;
				int num7 = 30;
				int num8 = 50;
				int num9 = 50;
				int num10 = 50;
				int num11 = 200;
				if (this.gc.challenges.Contains("WallsEasilySmashed"))
				{
					num7 = 5;
					num8 = 10;
					num9 = 50;
					num10 = 50;
					num11 = 200;
				}
				if (this.myMelee.agent.statusEffects.hasTrait("MeleeDestroysWalls2") && invItem.invItemName != "Fist")
				{
					num7 = 0;
					num8 = 0;
					num9 = 0;
					num10 = 0;
					num11 = 0;
				}
				else if (this.myMelee.agent.statusEffects.hasTrait("MeleeDestroysWalls") && invItem.invItemName != "Fist")
				{
					num7 = 0;
					num8 = 0;
					num9 = 0;
					num10 = 50;
					num11 = 200;
				}
				if (num6 >= num7)
				{
					TileData tileData2 = this.gc.tileInfo.GetTileData(hitObject.transform.position);
					if ((tileData2.wallMaterial == wallMaterialType.Wood && num6 >= num7) || (tileData2.wallMaterial == wallMaterialType.Normal && num6 >= num8) || (tileData2.wallMaterial == wallMaterialType.Steel && num6 >= num11) || (tileData2.wallMaterial == wallMaterialType.Border && num6 >= num10) || (tileData2.wallMaterial == wallMaterialType.Glass && num6 >= num9) || (num6 == num11 && tileData2.wallMaterial != wallMaterialType.Steel) || (num6 == num10 && tileData2.wallMaterial != wallMaterialType.Border && tileData2.wallMaterial != wallMaterialType.Steel && tileData2.wallMaterial != wallMaterialType.LockdownWall))
					{
						Door.freerAgent = this.myMelee.agent;
						this.gc.tileInfo.DestroyWallTileAtPosition(hitObject.transform.position.x, hitObject.transform.position.y, Vector3.zero, true, this.myMelee.agent, false, true, false, this.myMelee.agent, false);
						this.gc.audioHandler.Play(this.myMelee.agent, "WallDestroy");
						if (hitObject.name.Contains("Glass"))
						{
							this.gc.audioHandler.Play(this.myMelee.agent, "WallDestroyGlass");
						}
						hitObject.layer = 1;
						if (!hitObject.name.Contains("Border"))
						{
							this.gc.stats.AddDestructionQuestPoints();
						}
						if (this.myMelee.agent.isPlayer > 0 && this.myMelee.agent.localPlayer)
						{
							this.gc.stats.AddToStat(this.myMelee.agent, "Destruction", 1);
						}
						this.gc.ScreenShake(0.25f, 160f, this.myMelee.agent.tr.position, this.myMelee.agent);
						if (this.hitWall2 == 1)
						{
							this.gc.FreezeFrames(3);
							this.hitWall2 = 2;
						}
						else if (num6 != 200)
						{
							this.gc.FreezeFrames(3);
						}
						flag8 = true;
						if (invItem.invItemName != "Fist")
						{
							if (this.myMelee.depletedDuringThisAttack && invItem.invItemCount > 0)
							{
								this.myMelee.depletedDuringThisAttack = false;
								invItem.invItemCount += this.myMelee.depletedDuringThisAttackAmount;
							}
							if (this.myMelee.agent.statusEffects.hasTrait("MeleeDestroysWalls2"))
							{
								this.myMelee.agent.inventory.DepleteMelee(10);
							}
							else
							{
								this.myMelee.agent.inventory.DepleteMelee(20);
							}
						}
					}
				}
				if (this.myMelee.hitParticlesTr != null && this.myMelee.meleeContainerTr != null)
				{
					this.gc.spawnerMain.SpawnParticleEffect("ObjectDestroyed", this.myMelee.hitParticlesTr.position, this.myMelee.meleeContainerTr.eulerAngles.z - 90f);
				}
				if (!this.myMelee.successfullySleepKilled && !this.myMelee.agent.statusEffects.hasTrait("HitObjectsNoNoise") && (this.gc.serverPlayer || (!this.gc.serverPlayer && (this.myMelee.agent.localPlayer || this.myMelee.agent.mindControlAgent == this.gc.playerAgent))))
				{
					this.gc.spawnerMain.SpawnNoise(this.myMelee.agent.tr.position, 1f, null, null, this.myMelee.agent);
					if (flag8)
					{
						this.gc.spawnerMain.SpawnNoise(hitObject.transform.position, 1f, null, null, this.myMelee.agent);
					}
				}
				if (flag8 && this.myMelee.agent != null)
				{
					this.gc.OwnCheck(this.myMelee.agent, hitObject, "Normal", 0);
				}
				this.gc.audioHandler.Play(this.myMelee.agent, "BulletHitWall");
				this.gc.playerControl.Vibrate(this.myMelee.agent.isPlayer, Mathf.Clamp((float)this.myMelee.invItem.meleeDamage / 100f + 0.05f, 0f, 0.25f), Mathf.Clamp((float)this.myMelee.invItem.meleeDamage / 132f + 0.05f, 0f, 0.2f));
				if (!this.gc.serverPlayer && (this.myMelee.agent.localPlayer || this.myMelee.agent.mindControlAgent == this.gc.playerAgent))
				{
					if (this.myMelee.agent.isPlayer != 0)
					{
						this.myMelee.agent.objectMult.CallCmdMeleeHitWall(hitObject.transform.position);
						return;
					}
					this.gc.playerAgent.objectMult.CallCmdMeleeHitWallNPC(this.myMelee.agent.objectNetID, hitObject.transform.position);
				}
			}
		}
	}
}
