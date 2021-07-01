using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace CurioLab
{
    public enum MissionState
    {
        NotStarted,
        Started,
        Finished,
    }

    public class MissionInstance
    {
        public Mission missionTemplate;
        public float remainingTime;
        public MissionState state;
        public List<Character> characters;

        public MissionInstance(Mission template, List<Character> characters)
        {
            missionTemplate = template;
            this.characters = characters;
        }
        
        public void Start()
        {
            state = MissionState.Started;
            remainingTime = missionTemplate.duration;
            Debug.Log("Starting Mission");
        }
        
        public void Update(float deltaTime)
        {
            remainingTime -= deltaTime;
            Debug.Log($"Mission time remaining: {remainingTime} seconds.");
            if (remainingTime < 0f)
                End();
        }

        public void End()
        {
            
            remainingTime = 0f;
            state = MissionState.Finished;
            var rewards = missionTemplate.reward.Select(Object.Instantiate);

            var a = rewards.Select((x) => x.name);
            var b = string.Join("\n\t", a);
            Debug.Log($"Mission completed." +
                      $"Rewards Received: \n\t" + b );
            GameController.instance.inventory.AddRange(rewards);
        }
    }
}