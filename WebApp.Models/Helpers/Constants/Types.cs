using System;

namespace WebApp.Models.Helpers {

  public class Types {
    public const int Null = 0;

    public const int BiDays = 801;

    // Enum
    public const int PermissionLevel = 901; // Không có quyền, Có quyền, Có đầy đủ
    public const int ReceiptType = 902; // Không có quyền, Có quyền, Có đầy đủ
    public const int ReceiptStatus = 903; // Không có quyền, Có quyền, Có đầy đủ

    // Address
    public const int AD_Country = 101; // Quốc gia
    public const int AD_Province = 102; // Tỉnh/TP
    public const int AD_District = 103; // Quận/huyện
    public const int AD_Ward = 104; // Phường/xã

    // Common

    public const int CM_Muster = 1201;
    public const int CM_MusterDetail = 1202;
    public const int CM_Nation = 201; // Dân tộc
    public const int CM_Religion = 202; // Tôn giáo: Phật giáo, Thiên Chúa, Không
    public const int CM_Sex = 203; // Giới tính
    public const int CM_HalfLive = 206; // Bán trú

    // Student
    public const int ST_Area = 301; // Khu vực
    public const int ST_Disability = 302; // Khuyết tật
    public const int ST_Leave = 304;  // Lý do thôi học
    public const int ST_Object = 305;  // Đối tượng chính sách
    public const int ST_Status = 306; // Trạng thái học sinh

    // Official
    public const int OF_Contract = 401; // Hình thức hợp đồng
    public const int OF_Job = 402; // Vị trí việc làm: Nhân viên, Giáo viên
    public const int OF_Position = 403; // Chức vụ: Hiệu trường, phó, ý tế...
    public const int OF_Status = 404;  // Trạng thái cán bộ: Đang làm, nghĩ hưu...
    public const int OF_Quantum = 405; // Ngạch - hạng: GV hạng II, III, IV...
    public const int OF_DoubleMission = 406; // Nhiệm vụ kiêm nhiệm, đồng thời: Bí thư, chủ tịch công đoàn, kế toán...
    public const int OF_Wage = 407; // Bậc lương: 1, 2, 3, 4, 5, 6...
    public const int OF_FosteringRegularly = 408; // Bồi dưỡng thường xuyên: Tốt, khá, đạt
    public const int OF_Qualification = 409; // Trình độ chuyên môn, nghiệp vụ: Tiến sĩ, thạc sĩ
    public const int OF_PoliticalTheory = 410; // Trình độ lý luận chính trị: Sơ cấp, trung cấp, cao cấp, cử nhân
    public const int OF_StateManagement = 411; // Trình độ quản lý nhà nước: Chứng chỉ bồi dưỡng CBQL, Cử nhân, Thạc sĩ, Tiến sĩ
    public const int OF_ForeignLanguage = 412; // Ngoại ngữ: Anh, Nga, Pháp...
    public const int OF_ForeignLanguageType = 414; // Loại ngoại ngữ: A1, A2, B1, B2, IELTS, TOEFL...
    public const int OF_ForeignLanguageLevel = 415; // Trình độ ngoại ngữ: Tiến sĩ, thạc sĩ, đại học, cao đẳng...
    public const int OF_ForeignLanguageGroup = 416; // Nhóm ngoại ngữ: Trong nước, quốc tế...
    public const int OF_ForeignLanguageCapacity = 417; // Khung năng lực ngoại ngữ: Bậc 1, 2, 3, 4, 5...
    public const int OF_ComputerSkill = 418; // Trình độ tin học: Co bản TT03, Nâng cao TT03, Trung cấp, Chuẩn IC3...
    public const int OF_Specialized = 419; // Chuyên ngành" Giáo dục đặc biệt, mầm non, tiểu học, chính trị, toán, hóa...
    public const int OF_SpecializedLevel = 420; // Trình độ chuyên ngành: Trung cấp, cao đẳng, đại học tiến sĩ...
    public const int OF_SpecializedAddress = 425; // Trường đại tạo: Đại học sư phạm, TDTT, Nghệ thuật...
    public const int OF_JobStandards = 421; // Chuẩn nghề nghiệp: Tốt, khá, đạt, chưa đánh giá
    public const int OF_RateOfficial = 422; // Đánh giá viên chức: Xuất sắc, hoàn thành tốt, không hoàn thành...
    public const int OF_GoodTeacher = 423; // Giáo viên dạy giỏi: Cấp trường, cấp huyện, cấp tỉnh
    public const int OF_SessionsInDay = 424; // Buổi dạy trong tuần
    public const int OF_EvaluateValue = 426; // Buổi dạy trong tuần
    // Education
    public const int ED_Class = 1501;
    public const int ED_Student = 1502;
    public const int ED_Health = 1503;
    public const int ED_Official = 1504;
    public const int ED_Evaluate = 1505;
    public const int ED_EvaluateDetail = 1506;
    public const int ED_School = 501; // Điểm trường: Trụ sở chính...
    public const int ED_Program = 502; // Chương trình giáo dục mầm non chăm sóc giáo dục
    public const int ED_GroupClass = 503; // Nhóm lớp
    public const int ED_GroupOld = 504; // Nhóm tuổi
    public const int ED_Year = 505; // Năm học

    // Allowance
    public const int AT_Allowance = 1601;
    public const int AT_AllowanceTicket = 1602;
    public const int AT_AllowanceDetail = 1603;
    public const int AT_Tuition = 1604;
    public const int AT_TuitionTicket = 1605;
    public const int AT_TimeUnit = 601;

    // TicketType
    public const int AT_OvertimeTicketType = 601;
    public const int AT_TransferTicketType = 602;
    public const int AT_OverQuantityTicketType = 603;

    // Enum
    public const int EN_MusterDay = 901; // Kiểu nghỉ phép
  }
}