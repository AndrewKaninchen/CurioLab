using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CurioLab
{
    public class MissionController : MonoBehaviour
    {
        public List<MissionInstance> missions = new List<MissionInstance>();

        //TODO: tirar missão placeholder
        public Mission placeholderMission;

        public void StartMission(Mission mission, List<Character> characters)
        {
            mission ??= placeholderMission;
            var missionInstance = new MissionInstance(mission, characters); 
            
            missions.Add(missionInstance);
            missionInstance.Start();
        }

        private void Update()
        {
            foreach (var mission in missions.Where(x=>x.state == MissionState.Started))
            {
                mission.Update(Time.deltaTime);
            }
        }
    }
}