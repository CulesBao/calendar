using Calendar.DAL;
using Calender.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public ApptView GetApptView_BLL(Appt appt)
        {
            try
            {
                return new ApptView
                {
                    IDAppt = appt.IDAppt,
                    Creator = AccountBLL.Instance.GetUsername(appt.IDAccount),
                    NameAppt = appt.NameAppt,
                    LocationAppt = appt.LocationAppt,
                    TimeStart = appt.TimeStart,
                    TimeEnd = appt.TimeEnd
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error converting Appt to ApptView: {ex.Message}");
            }
        }

        public Appt GetApptMtByIDAppt_BLL(int IDAppt)
        {
            try
            {
                return ApptDAL.Instance.GetApptMtByIDAppt(IDAppt);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting meeting by IDAppt {IDAppt}: {ex.Message}");
            }
        }

        public ApptView GetApptViewByIDAppt_BLL(int IDAppt)
        {
            try
            {
                Appt a = ApptDAL.Instance.GetApptMtByIDAppt(IDAppt);
                if (a == null)
                    return null;

                return new ApptView
                {
                    IDAppt = IDAppt,
                    Creator = AccountBLL.Instance.GetUsername(a.IDAccount),
                    NameAppt = a.NameAppt,
                    LocationAppt = a.LocationAppt,
                    TimeStart = a.TimeStart,
                    TimeEnd = a.TimeEnd
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting ApptView by IDAppt {IDAppt}: {ex.Message}");
            }
        }

        public List<ApptView> GetListApptViewNotMtByIDAcc_BLL(int IDAccount)
        {
            try
            {
                List<ApptView> listApptView = new List<ApptView>();
                foreach (Appt appt in ApptDAL.Instance.GetAllApptNotMtByIDAcc_DAL(IDAccount))
                {
                    listApptView.Add(GetApptView_BLL(appt));
                }
                return listApptView;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting non-meeting ApptViews for IDAccount {IDAccount}: {ex.Message}");
            }
        }

        public Appt CheckSameAppt_BLL(Appt a)
        {
            try
            {
                // Đẩy logic kiểm tra xuống DAL để tối ưu
                return ApptDAL.Instance.CheckAppointmentOverlap_DAL(a.IDAccount, a.TimeStart, a.TimeEnd);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking appointment overlap: {ex.Message}");
            }
        }

        public Appt CheckSameApptNotMtByIDAcc_BLL(Appt a)
        {
            try
            {
                return ApptDAL.Instance.CheckNonMeetingAppointmentOverlap_DAL(a.IDAccount, a.TimeStart, a.TimeEnd);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking non-meeting appointment overlap: {ex.Message}");
            }
        }

        public List<ApptView> GetListApptViewMt_BLL(int IDAccount)
        {
            try
            {
                List<ApptView> listApptView = new List<ApptView>();

                // Meeting do IDAccount tạo
                foreach (Appt appt in ApptDAL.Instance.GetAllApptMtByIDAcc_DAL(IDAccount))
                {
                    listApptView.Add(GetApptView_BLL(appt));
                }

                // Meeting IDAccount tham gia
                foreach (Meeting mt in ApptDAL.Instance.GetAllMeetingByIDAccount_DAL(IDAccount))
                {
                    ApptView view = GetApptViewByIDAppt_BLL(mt.IDAppt);
                    if (view != null)
                        listApptView.Add(view);
                }

                // Loại bỏ trùng lặp dựa trên IDAppt
                return listApptView
                    .GroupBy(v => v.IDAppt)
                    .Select(g => g.First())
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting meeting ApptViews for IDAccount {IDAccount}: {ex.Message}");
            }
        }

        public bool IsSameApptViewMt_BLL(Appt a)
        {
            try
            {
                return ApptDAL.Instance.CheckMeetingOverlap_DAL(a.IDAccount, a.NameAppt, a.TimeStart, a.TimeEnd);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking meeting overlap: {ex.Message}");
            }
        }

        public List<ApptView> GetSameApptMtNotByIDAcc_BLL(Appt a)
        {
            try
            {
                List<ApptView> listApptView = new List<ApptView>();
                foreach (Appt appt in ApptDAL.Instance.GetAllApptMtNotByIDAcc_DAL(a.IDAccount))
                {
                    if (appt.TimeStart == a.TimeStart && appt.TimeEnd == a.TimeEnd && appt.NameAppt == a.NameAppt)
                    {
                        listApptView.Add(GetApptView_BLL(appt));
                    }
                }
                return listApptView;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting matching meeting ApptViews: {ex.Message}");
            }
        }

        public List<ApptView> GetApptViewReminderByIDAcc_BLL(int IDAccount)
        {
            try
            {
                List<ApptView> listApptView = new List<ApptView>();
                foreach (Appt appt in ApptDAL.Instance.GetAllReminderByIDAccount_DAL(IDAccount))
                {
                    listApptView.Add(GetApptView_BLL(appt));
                }
                return listApptView;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting reminder ApptViews for IDAccount {IDAccount}: {ex.Message}");
            }
        }

        public void AddAppt_BLL(Appt appt)
        {
            try
            {
                ApptDAL.Instance.AddAppt_DAL(appt);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding appointment: {ex.Message}");
            }
        }

        public void UpdateAppt_BLL(Appt appt)
        {
            try
            {
                ApptDAL.Instance.UpdateAppt_DAL(appt);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating appointment: {ex.Message}");
            }
        }

        public void AddMeeting_BLL(Appt appt, int idAcc)
        {
            try
            {
                ApptDAL.Instance.AddMeeting_DAL(appt, idAcc);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding to meeting: {ex.Message}");
            }
        }

        public List<Account> GetListAccountSameMeeting_BLL(int IDAppt)
        {
            try
            {
                List<Account> list = new List<Account>();
                foreach (int id in ApptDAL.Instance.GetListIDAccountSameMeeting_DAL(IDAppt))
                {
                    Account acc = AccountDAL.Instance.GetAccountByIDAcc(id);
                    if (acc != null)
                        list.Add(acc);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting accounts for meeting IDAppt {IDAppt}: {ex.Message}");
            }
        }
    }
}