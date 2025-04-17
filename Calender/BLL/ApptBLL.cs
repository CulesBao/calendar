using Calender.DTO;
using Calender.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;

namespace Calender.BLL
{
    internal class ApptBLL
    {
        private static ApptBLL _Instance;

        public static ApptBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ApptBLL();
                }
                return _Instance;
            }
            private set { }
        }

        public ApptBLL()
        {

        }

        //lấy ra ApptView từ appt
        public ApptView GetApptView_BLL(Appt appt)
        {
            ApptView apptView = new ApptView()
            {
                IDAppt = appt.IDAppt,
                Creator = AccountBLL.Instance.GetUsername(appt.IDAccount),
                NameAppt = appt.NameAppt,
                LocationAppt = appt.LocationAppt,
                TimeStart = appt.TimeStart,
                TimeEnd = appt.TimeEnd,
            };
            return apptView;
        }

        //lấy ra Appt là meeting từ IDAppt
        public Appt GetApptMtByIDAppt_BLL(int IDAppt)
        {
            return ApptDAL.Instance.GetApptMtByIDAppt(IDAppt);
        }

        //lấy ra ApptView là meeting từ IDAppt
        public ApptView GetApptViewByIDAppt_BLL(int IDAppt)
        {
            Appt a = ApptDAL.Instance.GetApptMtByIDAppt(IDAppt);

            ApptView apptView = new ApptView()
            {
                IDAppt = IDAppt,
                Creator = AccountBLL.Instance.GetUsername(a.IDAccount),
                NameAppt = a.NameAppt,
                LocationAppt = a.LocationAppt,
                TimeStart = a.TimeStart,
                TimeEnd = a.TimeEnd,
            };
            return apptView;
        }


        //list ApptView không là meeting + có cùng IDAcc
        public List<ApptView> GetListApptViewNotMtByIDAcc_BLL(int IDAccount)
        {
            List<ApptView> listApptView = new List<ApptView>();
            foreach (Appt appt in ApptDAL.Instance.GetAllApptNotMtByIDAcc_DAL(IDAccount))
            {
                listApptView.Add(GetApptView_BLL(appt));
            }
            return listApptView;
        }

        //kiểm tra xem có appt (phải hoặc k phải meeting) bị trùng tgian không
        public Appt CheckSameAppt_BLL(Appt a)
        {
            foreach (Appt appt in ApptDAL.Instance.GetAllAppt_DAL(a.IDAccount))
            {
                if (a.TimeStart >= appt.TimeStart && a.TimeStart < appt.TimeEnd)
                {
                    return appt;
                }
            }
            return null;
        }

        //kiểm tra xem có appt không là meeting + có cùng IDAcc bị trùng tgian không
        public Appt CheckSameApptNotMtByIDAcc_BLL(Appt a)
        {
            foreach (Appt appt in ApptDAL.Instance.GetAllApptNotMtByIDAcc_DAL(a.IDAccount))
            {
                if (a.TimeStart >= appt.TimeStart && a.TimeStart < appt.TimeEnd)
                {
                    return appt;
                }
            }
            return null;
        }

        //list ApptView là appt meeting do IDAcc tạo và tham gia
        public List<ApptView> GetListApptViewMt_BLL(int IDAccount)
        {
            List<ApptView> listApptView = new List<ApptView>();

            //meeting do IDAcc tạo
            foreach(Appt appt in ApptDAL.Instance.GetAllApptMtByIDAcc_DAL(IDAccount))
            {
                listApptView.Add(GetApptView_BLL(appt));
            }

            //meeting IDAcc tham gia
            foreach (Meeting mt in ApptDAL.Instance.GetAllMeetingByIDAccount_DAL(IDAccount))
            {
                listApptView.Add(GetApptViewByIDAppt_BLL(mt.IDAppt));
            }

            return listApptView;
        }

        //kiểm tra có ApptView là appt meeting do IDAcc tạo và tham gia bị trùng không
        public bool IsSameApptViewMt_BLL(Appt a)
        {
            List<ApptView> listApptView = new List<ApptView>();

            //meeting do IDAcc tạo
            foreach (Appt appt in ApptDAL.Instance.GetAllApptMtByIDAcc_DAL(a.IDAccount))
            {
                if (DateTime.Compare(a.TimeStart, appt.TimeStart) == 0 && DateTime.Compare(a.TimeEnd, appt.TimeEnd) == 0)
                {
                    return true;
                }
            }

            //meeting IDAcc tham gia
            foreach (Meeting mt in ApptDAL.Instance.GetAllMeetingByIDAccount_DAL(a.IDAccount))
            {
                ApptView av = GetApptViewByIDAppt_BLL(mt.IDAppt);
                if (DateTime.Compare(a.TimeStart, av.TimeStart) == 0 && DateTime.Compare(a.TimeEnd, av.TimeEnd) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        //list ApptView là appt meeting + khác IDAcc có trùng địa điểm và tgian
        public List<ApptView> GetSameApptMtNotByIDAcc_BLL(Appt a)
        {
            List<ApptView> listApptView = new List<ApptView>();
            foreach (Appt appt in ApptDAL.Instance.GetAllApptMtNotByIDAcc_DAL(a.IDAccount))
            {
                if (DateTime.Compare(a.TimeStart, appt.TimeStart) == 0 && DateTime.Compare(a.TimeEnd, appt.TimeEnd) == 0 && a.NameAppt == appt.NameAppt)
                {
                    listApptView.Add(GetApptView_BLL(appt));
                }
            }
            return listApptView;
        }

        //list Reminder của 1 người
        public List<ApptView> GetApptViewReminderByIDAcc_BLL(int IDAccount)
        {
            List<ApptView> listApptView = new List<ApptView>();
            foreach (Appt appt in ApptDAL.Instance.GetAllReminderByIDAccount_DAL(IDAccount))
            {
                listApptView.Add(GetApptView_BLL(appt));
            }
            return listApptView;
        }

        public void AddAppt_BLL(Appt appt)
        {
            ApptDAL.Instance.AddAppt_DAL(appt);
        }

        public void UpdateAppt_BLL(Appt appt)
        {
            ApptDAL.Instance.UpdateAppt_DAL(appt);
        }

        public void AddMeeting_BLL(Appt appt, int idAcc)
        {
            ApptDAL.Instance.AddMeeting_DAL(appt, idAcc);
        }

        //list acc tham gia vào cùng 1 meeting
        public List<Account> GetListAccountSameMeeting_BLL(int IDAppt)
        {
            List<Account> list = new List<Account> ();
            foreach(int i in ApptDAL.Instance.GetListIDAccountSameMeeting_DAL(IDAppt))
            {
                list.Add(AccountDAL.Instance.GetAccountByIDAcc(i));
            }
            return list;
        }
    }
}
