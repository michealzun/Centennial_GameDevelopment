using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireCloud.Mission
{
    public enum Type { Defend, Rescue, Sabotage, Assassination }
    public enum Status { NotStart, InProgress, Compeleted }

    [CreateAssetMenu(fileName = "Mission", menuName = "Mission/Mission", order = 1)]
    public class Mission : ScriptableObject
    {
        public uint MissionId = 0;
        public string Title = "";
        public Type Type;
        [HideInInspector]
        public Status Status = Status.NotStart;
        private int _compeletedCount = 0;
        [TextArea]
        public string Description;
        public int RewardExp;

        /// <summary>
        /// Callback when mission completed.
        /// </summary>
        /// <param name="m">Mission</param>
        public delegate void OnCompeletedEventHandler(Mission m);
        public event OnCompeletedEventHandler OnCompeleted;

        /// <summary>
        /// Callback for mission progress update.
        /// </summary>
        /// <param name="m"></param>
        public delegate void OnProgressUpdatedEventHandler(Mission m);
        public event OnProgressUpdatedEventHandler OnProgressUpdated;

        /// <summary>
        /// Completed count for the mission, this will automatically call completed and update when count changes.
        /// </summary>
        public int CompletedCount
        {
            set
            {
                this._compeletedCount = value;
                if (this._compeletedCount == 0)
                {
                    Status = Status.NotStart;
                    return;
                }
                if (_compeletedCount >= TotalRequired)
                {
                    Status = Status.Compeleted;
                    if (OnCompeleted != null)
                    {
                        OnCompeleted.Invoke(this);
                    }
                }
                else
                {
                    Status = Status.InProgress;
                    if (OnProgressUpdated != null)
                    {
                        OnProgressUpdated.Invoke(this);
                    }
                }
            }
            get
            {
                return this._compeletedCount;
            }
        }
        public int TotalRequired = 0;
        public MissionTargetType MissionTargetType;

        public void ResetMission()
        {
            CompletedCount = 0;
        }
    }
}