﻿using System;

#if !__ANDROID__
using System.Windows.Input;
#endif

using ProtoBuf;
#if __ANDROID__
using SQLite;
#endif

namespace NORSU.EncodeMe.Network
{
    [ProtoContract]
    [Serializable]
    class ClassSchedule : Message<ClassSchedule>
    {
        private long _ClassId;

        [ProtoMember(1)]
#if __ANDROID__
        [PrimaryKey]
#endif
        public long ClassId
        {
            get => _ClassId;
            set
            {
                if (value == _ClassId) return;
                _ClassId = value;
                OnPropertyChanged(nameof(ClassId));
            }
        }

        private string _Schedule;
        [ProtoMember(2)]
        public string Schedule
        {
            get => _Schedule;
            set
            {
                if (value == _Schedule) return;
                _Schedule = value;
                OnPropertyChanged(nameof(Schedule));
            }
        }

        private string _Instructor;

        [ProtoMember(3)]
        public string Instructor
        {
            get => _Instructor;
            set
            {
                if (value == _Instructor) return;
                _Instructor = value;
                OnPropertyChanged(nameof(Instructor));
            }
        }

        private int _Slots;
        [ProtoMember(4)]
        public int Slots
        {
            get => _Slots;
            set
            {
                if (value == _Slots) return;
                _Slots = value;
                OnPropertyChanged(nameof(Slots));
            }
        }
        
        private int _Enrolled;
        [ProtoMember(5)]
        public int Enrolled
        {
            get => _Enrolled;
            set
            {
                if (value == _Enrolled) return;
                _Enrolled = value;
                OnPropertyChanged(nameof(Enrolled));
            }
        }

        private string _Room;
        [ProtoMember(6)]
        public string Room
        {
            get => _Room;
            set
            {
                if (value == _Room) return;
                _Room = value;
                OnPropertyChanged(nameof(Room));
            }
        }

        private string _SubjectCode;
        [ProtoMember(7)]
        public string SubjectCode
        {
            get => _SubjectCode;
            set
            {
                if (value == _SubjectCode) return;
                _SubjectCode = value;
                OnPropertyChanged(nameof(SubjectCode));
            }
        }
        
        public bool Sent { get; set; }

        private ScheduleStatuses _enrollmentStatus;

        [ProtoMember(8)]
        public ScheduleStatuses EnrollmentStatus
        {
            get => _enrollmentStatus;
            set
            {
                if (value == _enrollmentStatus) return;
                _enrollmentStatus = value; 
                OnPropertyChanged(nameof(EnrollmentStatus));
            }
        }

#if !__ANDROID__
        private ICommand _toggleStatusCommand;

        public ICommand ToggleStatusCommand => _toggleStatusCommand ??
                                               (_toggleStatusCommand = new DelegateCommand(c =>
                                               {
                                                   if (EnrollmentStatus == ScheduleStatuses.Accepted)
                                                       EnrollmentStatus = ScheduleStatuses.Closed;
                                                   else if (EnrollmentStatus == ScheduleStatuses.Closed)
                                                       EnrollmentStatus = ScheduleStatuses.Conflict;
                                                   else
                                                       EnrollmentStatus = ScheduleStatuses.Accepted;

                                               }));
        
        private bool _IsSelected;

        public bool IsSelected
        {
            get => _IsSelected;
            set
            {
                if (value == _IsSelected) return;
                _IsSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
#endif

        //public void Dispose()
        //{

        //}

        //public IntPtr Handle { get; }

        //public int DescribeContents()
        //{
        //    return 0;
        //}

        //public void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
        //{
        //    dest.WriteLong(ClassId);
        //    dest.WriteInt(Enrolled);
        //    dest.WriteString(Instructor);
        //    dest.WriteString(Room);
        //    dest.WriteString(Schedule);
        //    dest.writeb
        //}
    }
}
