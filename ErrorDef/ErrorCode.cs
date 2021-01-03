// Decompiled with JetBrains decompiler
// Type: ErrorDef.ErrorCode
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Locales;

namespace ErrorDef
{
    internal class ErrorCode
    {
        public const long SUCCESS = 0;
        public const long ERROR_INVALID_FUNCTION = 1;
        public const long ERROR_FILE_NOT_FOUND = 2;
        public const long ERROR_PATH_NOT_FOUND = 3;
        public const long ERROR_TOO_MANY_OPEN_FILES = 4;
        public const long ERROR_ACCESS_DENIED = 5;
        public const long ERROR_INVALID_HANDLE = 6;
        public const long ERROR_ARENA_TRASHED = 7;
        public const long ERROR_NOT_ENOUGH_MEMORY = 8;
        public const long ERROR_INVALID_BLOCK = 9;
        public const long ERROR_BAD_ENVIRONMENT = 10;
        public const long ERROR_BAD_FORMAT = 11;
        public const long ERROR_INVALID_ACCESS = 12;
        public const long ERROR_INVALID_DATA = 13;
        public const long ERROR_OUTOFMEMORY = 14;
        public const long ERROR_INVALID_DRIVE = 15;
        public const long ERROR_CURRENT_DIRECTORY = 16;
        public const long ERROR_NOT_SAME_DEVICE = 17;
        public const long ERROR_NO_MORE_FILES = 18;
        public const long ERROR_WRITE_PROTECT = 19;
        public const long ERROR_BAD_UNIT = 20;
        public const long ERROR_NOT_READY = 21;
        public const long ERROR_BAD_COMMAND = 22;
        public const long ERROR_CRC = 23;
        public const long ERROR_BAD_LENGTH = 24;
        public const long ERROR_SEEK = 25;
        public const long ERROR_NOT_DOS_DISK = 26;
        public const long ERROR_SECTOR_NOT_FOUND = 27;
        public const long ERROR_OUT_OF_PAPER = 28;
        public const long ERROR_WRITE_FAULT = 29;
        public const long ERROR_READ_FAULT = 30;
        public const long ERROR_GEN_FAILURE = 31;
        public const long ERROR_SHARING_VIOLATION = 32;
        public const long ERROR_LOCK_VIOLATION = 33;
        public const long ERROR_WRONG_DISK = 34;
        public const long ERROR_SHARING_BUFFER_EXCEEDED = 36;
        public const long ERROR_HANDLE_EOF = 38;
        public const long ERROR_HANDLE_DISK_FULL = 39;
        public const long ERROR_NOT_SUPPORTED = 50;
        public const long ERROR_REM_NOT_LIST = 51;
        public const long ERROR_DUP_NAME = 52;
        public const long ERROR_BAD_NETPATH = 53;
        public const long ERROR_NETWORK_BUSY = 54;
        public const long ERROR_DEV_NOT_EXIST = 55;
        public const long ERROR_TOO_MANY_CMDS = 56;
        public const long ERROR_ADAP_HDW_ERR = 57;
        public const long ERROR_BAD_NET_RESP = 58;
        public const long ERROR_UNEXP_NET_ERR = 59;
        public const long ERROR_BAD_REM_ADAP = 60;
        public const long ERROR_PRINTQ_FULL = 61;
        public const long ERROR_NO_SPOOL_SPACE = 62;
        public const long ERROR_PRINT_CANCELLED = 63;
        public const long ERROR_NETNAME_DELETED = 64;
        public const long ERROR_NETWORK_ACCESS_DENIED = 65;
        public const long ERROR_BAD_DEV_TYPE = 66;
        public const long ERROR_BAD_NET_NAME = 67;
        public const long ERROR_TOO_MANY_NAMES = 68;
        public const long ERROR_TOO_MANY_SESS = 69;
        public const long ERROR_SHARING_PAUSED = 70;
        public const long ERROR_REQ_NOT_ACCEP = 71;
        public const long ERROR_REDIR_PAUSED = 72;
        public const long ERROR_FILE_EXISTS = 80;
        public const long ERROR_CANNOT_MAKE = 82;
        public const long ERROR_FAIL_I24 = 83;
        public const long ERROR_OUT_OF_STRUCTURES = 84;
        public const long ERROR_ALREADY_ASSIGNED = 85;
        public const long ERROR_INVALID_PASSWORD = 86;
        public const long ERROR_INVALID_PARAMETER = 87;
        public const long ERROR_NET_WRITE_FAULT = 88;
        public const long ERROR_NO_PROC_SLOTS = 89;
        public const long ERROR_TOO_MANY_SEMAPHORES = 100;
        public const long ERROR_EXCL_SEM_ALREADY_OWNED = 101;
        public const long ERROR_SEM_IS_SET = 102;
        public const long ERROR_TOO_MANY_SEM_REQUESTS = 103;
        public const long ERROR_INVALID_AT_INTERRUPT_TIME = 104;
        public const long ERROR_SEM_OWNER_DIED = 105;
        public const long ERROR_SEM_USER_LIMIT = 106;
        public const long ERROR_DISK_CHANGE = 107;
        public const long ERROR_DRIVE_LOCKED = 108;
        public const long ERROR_BROKEN_PIPE = 109;
        public const long ERROR_OPEN_FAILED = 110;
        public const long ERROR_BUFFER_OVERFLOW = 111;
        public const long ERROR_DISK_FULL = 112;
        public const long ERROR_NO_MORE_SEARCH_HANDLES = 113;
        public const long ERROR_INVALID_TARGET_HANDLE = 114;
        public const long ERROR_INVALID_CATEGORY = 117;
        public const long ERROR_INVALID_VERIFY_SWITCH = 118;
        public const long ERROR_BAD_DRIVER_LEVEL = 119;
        public const long ERROR_CALL_NOT_IMPLEMENTED = 120;
        public const long ERROR_SEM_TIMEOUT = 121;
        public const long ERROR_INSUFFICIENT_BUFFER = 122;
        public const long ERROR_INVALID_NAME = 123;
        public const long ERROR_INVALID_LEVEL = 124;
        public const long ERROR_NO_VOLUME_LABEL = 125;
        public const long ERROR_MOD_NOT_FOUND = 126;
        public const long ERROR_PROC_NOT_FOUND = 127;
        public const long ERROR_WAIT_NO_CHILDREN = 128;
        public const long ERROR_CHILD_NOT_COMPLETE = 129;
        public const long ERROR_DIRECT_ACCESS_HANDLE = 130;
        public const long ERROR_NEGATIVE_SEEK = 131;
        public const long ERROR_SEEK_ON_DEVICE = 132;
        public const long ERROR_IS_JOIN_TARGET = 133;
        public const long ERROR_IS_JOINED = 134;
        public const long ERROR_IS_SUBSTED = 135;
        public const long ERROR_NOT_JOINED = 136;
        public const long ERROR_NOT_SUBSTED = 137;
        public const long ERROR_JOIN_TO_JOIN = 138;
        public const long ERROR_SUBST_TO_SUBST = 139;
        public const long ERROR_JOIN_TO_SUBST = 140;
        public const long ERROR_SUBST_TO_JOIN = 141;
        public const long ERROR_BUSY_DRIVE = 142;
        public const long ERROR_SAME_DRIVE = 143;
        public const long ERROR_DIR_NOT_ROOT = 144;
        public const long ERROR_DIR_NOT_EMPTY = 145;
        public const long ERROR_IS_SUBST_PATH = 146;
        public const long ERROR_IS_JOIN_PATH = 147;
        public const long ERROR_PATH_BUSY = 148;
        public const long ERROR_IS_SUBST_TARGET = 149;
        public const long ERROR_SYSTEM_TRACE = 150;
        public const long ERROR_INVALID_EVENT_COUNT = 151;
        public const long ERROR_TOO_MANY_MUXWAITERS = 152;
        public const long ERROR_INVALID_LIST_FORMAT = 153;
        public const long ERROR_LABEL_TOO_LONG = 154;
        public const long ERROR_TOO_MANY_TCBS = 155;
        public const long ERROR_SIGNAL_REFUSED = 156;
        public const long ERROR_DISCARDED = 157;
        public const long ERROR_NOT_LOCKED = 158;
        public const long ERROR_BAD_THREADID_ADDR = 159;
        public const long ERROR_BAD_ARGUMENTS = 160;
        public const long ERROR_BAD_PATHNAME = 161;
        public const long ERROR_SIGNAL_PENDING = 162;
        public const long ERROR_MAX_THRDS_REACHED = 164;
        public const long ERROR_LOCK_FAILED = 167;
        public const long ERROR_BUSY = 170;
        public const long ERROR_CANCEL_VIOLATION = 173;
        public const long ERROR_ATOMIC_LOCKS_NOT_SUPPORTED = 174;
        public const long ERROR_INVALID_SEGMENT_NUMBER = 180;
        public const long ERROR_INVALID_ORDINAL = 182;
        public const long ERROR_ALREADY_EXISTS = 183;
        public const long ERROR_INVALID_FLAG_NUMBER = 186;
        public const long ERROR_SEM_NOT_FOUND = 187;
        public const long ERROR_INVALID_STARTING_CODESEG = 188;
        public const long ERROR_INVALID_STACKSEG = 189;
        public const long ERROR_INVALID_MODULETYPE = 190;
        public const long ERROR_INVALID_EXE_SIGNATURE = 191;
        public const long ERROR_EXE_MARKED_INVALID = 192;
        public const long ERROR_BAD_EXE_FORMAT = 193;
        public const long ERROR_ITERATED_DATA_EXCEEDS_64k = 194;
        public const long ERROR_INVALID_MINALLOCSIZE = 195;
        public const long ERROR_DYNLINK_FROM_INVALID_RING = 196;
        public const long ERROR_IOPL_NOT_ENABLED = 197;
        public const long ERROR_INVALID_SEGDPL = 198;
        public const long ERROR_AUTODATASEG_EXCEEDS_64k = 199;
        public const long ERROR_RING2SEG_MUST_BE_MOVABLE = 200;
        public const long ERROR_RELOC_CHAIN_XEEDS_SEGLIM = 201;
        public const long ERROR_INFLOOP_IN_RELOC_CHAIN = 202;
        public const long ERROR_ENVVAR_NOT_FOUND = 203;
        public const long ERROR_NO_SIGNAL_SENT = 205;
        public const long ERROR_FILENAME_EXCED_RANGE = 206;
        public const long ERROR_RING2_STACK_IN_USE = 207;
        public const long ERROR_META_EXPANSION_TOO_LONG = 208;
        public const long ERROR_INVALID_SIGNAL_NUMBER = 209;
        public const long ERROR_THREAD_1_INACTIVE = 210;
        public const long ERROR_LOCKED = 212;
        public const long ERROR_TOO_MANY_MODULES = 214;
        public const long ERROR_NESTING_NOT_ALLOWED = 215;
        public const long ERROR_EXE_MACHINE_TYPE_MISMATCH = 216;
        public const long ERROR_EXE_CANNOT_MODIFY_SIGNED_BINARY = 217;
        public const long ERROR_EXE_CANNOT_MODIFY_STRONG_SIGNED_BINARY = 218;
        public const long ERROR_BAD_PIPE = 230;
        public const long ERROR_PIPE_BUSY = 231;
        public const long ERROR_NO_DATA = 232;
        public const long ERROR_PIPE_NOT_CONNECTED = 233;
        public const long ERROR_MORE_DATA = 234;
        public const long ERROR_VC_DISCONNECTED = 240;
        public const long ERROR_INVALID_EA_NAME = 254;
        public const long ERROR_EA_LIST_INCONSISTENT = 255;
        public const long WAIT_TIMEOUT = 258;
        public const long ERROR_NO_MORE_ITEMS = 259;
        public const long ERROR_CANNOT_COPY = 266;
        public const long ERROR_DIRECTORY = 267;
        public const long ERROR_EAS_DIDNT_FIT = 275;
        public const long ERROR_EA_FILE_CORRUPT = 276;
        public const long ERROR_EA_TABLE_FULL = 277;
        public const long ERROR_INVALID_EA_HANDLE = 278;
        public const long ERROR_EAS_NOT_SUPPORTED = 282;
        public const long ERROR_NOT_OWNER = 288;
        public const long ERROR_TOO_MANY_POSTS = 298;
        public const long ERROR_PARTIAL_COPY = 299;
        public const long ERROR_OPLOCK_NOT_GRANTED = 300;
        public const long ERROR_INVALID_OPLOCK_PROTOCOL = 301;
        public const long ERROR_DISK_TOO_FRAGMENTED = 302;
        public const long ERROR_DELETE_PENDING = 303;
        public const long ERROR_MR_MID_NOT_FOUND = 317;
        public const long ERROR_SCOPE_NOT_FOUND = 318;
        public const long ERROR_INVALID_ADDRESS = 487;
        public const long ERROR_ARITHMETIC_OVERFLOW = 534;
        public const long ERROR_PIPE_CONNECTED = 535;
        public const long ERROR_PIPE_LISTENING = 536;
        public const long ERROR_EA_ACCESS_DENIED = 994;
        public const long ERROR_OPERATION_ABORTED = 995;
        public const long ERROR_IO_INCOMPLETE = 996;
        public const long ERROR_IO_PENDING = 997;
        public const long ERROR_NOACCESS = 998;
        public const long ERROR_SWAPERROR = 999;
        public const long ERROR_STACK_OVERFLOW = 1001;
        public const long ERROR_INVALID_MESSAGE = 1002;
        public const long ERROR_CAN_NOT_COMPLETE = 1003;
        public const long ERROR_INVALID_FLAGS = 1004;
        public const long ERROR_UNRECOGNIZED_VOLUME = 1005;
        public const long ERROR_FILE_INVALID = 1006;
        public const long ERROR_FULLSCREEN_MODE = 1007;
        public const long ERROR_NO_TOKEN = 1008;
        public const long ERROR_BADDB = 1009;
        public const long ERROR_BADKEY = 1010;
        public const long ERROR_CANTOPEN = 1011;
        public const long ERROR_CANTREAD = 1012;
        public const long ERROR_CANTWRITE = 1013;
        public const long ERROR_REGISTRY_RECOVERED = 1014;
        public const long ERROR_REGISTRY_CORRUPT = 1015;
        public const long ERROR_REGISTRY_IO_FAILED = 1016;
        public const long ERROR_NOT_REGISTRY_FILE = 1017;
        public const long ERROR_KEY_DELETED = 1018;
        public const long ERROR_NO_LOG_SPACE = 1019;
        public const long ERROR_KEY_HAS_CHILDREN = 1020;
        public const long ERROR_CHILD_MUST_BE_VOLATILE = 1021;
        public const long ERROR_NOTIFY_ENUM_DIR = 1022;
        public const long ERROR_DEPENDENT_SERVICES_RUNNING = 1051;
        public const long ERROR_INVALID_SERVICE_CONTROL = 1052;
        public const long ERROR_SERVICE_REQUEST_TIMEOUT = 1053;
        public const long ERROR_SERVICE_NO_THREAD = 1054;
        public const long ERROR_SERVICE_DATABASE_LOCKED = 1055;
        public const long ERROR_SERVICE_ALREADY_RUNNING = 1056;
        public const long ERROR_INVALID_SERVICE_ACCOUNT = 1057;
        public const long ERROR_SERVICE_DISABLED = 1058;
        public const long ERROR_CIRCULAR_DEPENDENCY = 1059;
        public const long ERROR_SERVICE_DOES_NOT_EXIST = 1060;
        public const long ERROR_SERVICE_CANNOT_ACCEPT_CTRL = 1061;
        public const long ERROR_SERVICE_NOT_ACTIVE = 1062;
        public const long ERROR_FAILED_SERVICE_CONTROLLER_CONNECT = 1063;
        public const long ERROR_EXCEPTION_IN_SERVICE = 1064;
        public const long ERROR_DATABASE_DOES_NOT_EXIST = 1065;
        public const long ERROR_SERVICE_SPECIFIC_ERROR = 1066;
        public const long ERROR_PROCESS_ABORTED = 1067;
        public const long ERROR_SERVICE_DEPENDENCY_FAIL = 1068;
        public const long ERROR_SERVICE_LOGON_FAILED = 1069;
        public const long ERROR_SERVICE_START_HANG = 1070;
        public const long ERROR_INVALID_SERVICE_LOCK = 1071;
        public const long ERROR_SERVICE_MARKED_FOR_DELETE = 1072;
        public const long ERROR_SERVICE_EXISTS = 1073;
        public const long ERROR_ALREADY_RUNNING_LKG = 1074;
        public const long ERROR_SERVICE_DEPENDENCY_DELETED = 1075;
        public const long ERROR_BOOT_ALREADY_ACCEPTED = 1076;
        public const long ERROR_SERVICE_NEVER_STARTED = 1077;
        public const long ERROR_DUPLICATE_SERVICE_NAME = 1078;
        public const long ERROR_DIFFERENT_SERVICE_ACCOUNT = 1079;
        public const long ERROR_CANNOT_DETECT_DRIVER_FAILURE = 1080;
        public const long ERROR_CANNOT_DETECT_PROCESS_ABORT = 1081;
        public const long ERROR_NO_RECOVERY_PROGRAM = 1082;
        public const long ERROR_SERVICE_NOT_IN_EXE = 1083;
        public const long ERROR_NOT_SAFEBOOT_SERVICE = 1084;
        public const long ERROR_END_OF_MEDIA = 1100;
        public const long ERROR_FILEMARK_DETECTED = 1101;
        public const long ERROR_BEGINNING_OF_MEDIA = 1102;
        public const long ERROR_SETMARK_DETECTED = 1103;
        public const long ERROR_NO_DATA_DETECTED = 1104;
        public const long ERROR_PARTITION_FAILURE = 1105;
        public const long ERROR_INVALID_BLOCK_LENGTH = 1106;
        public const long ERROR_DEVICE_NOT_PARTITIONED = 1107;
        public const long ERROR_UNABLE_TO_LOCK_MEDIA = 1108;
        public const long ERROR_UNABLE_TO_UNLOAD_MEDIA = 1109;
        public const long ERROR_MEDIA_CHANGED = 1110;
        public const long ERROR_BUS_RESET = 1111;
        public const long ERROR_NO_MEDIA_IN_DRIVE = 1112;
        public const long ERROR_NO_UNICODE_TRANSLATION = 1113;
        public const long ERROR_DLL_INIT_FAILED = 1114;
        public const long ERROR_SHUTDOWN_IN_PROGRESS = 1115;
        public const long ERROR_NO_SHUTDOWN_IN_PROGRESS = 1116;
        public const long ERROR_IO_DEVICE = 1117;
        public const long ERROR_SERIAL_NO_DEVICE = 1118;
        public const long ERROR_IRQ_BUSY = 1119;
        public const long ERROR_MORE_WRITES = 1120;
        public const long ERROR_COUNTER_TIMEOUT = 1121;
        public const long ERROR_FLOPPY_ID_MARK_NOT_FOUND = 1122;
        public const long ERROR_FLOPPY_WRONG_CYLINDER = 1123;
        public const long ERROR_FLOPPY_UNKNOWN_ERROR = 1124;
        public const long ERROR_FLOPPY_BAD_REGISTERS = 1125;
        public const long ERROR_DISK_RECALIBRATE_FAILED = 1126;
        public const long ERROR_DISK_OPERATION_FAILED = 1127;
        public const long ERROR_DISK_RESET_FAILED = 1128;
        public const long ERROR_EOM_OVERFLOW = 1129;
        public const long ERROR_NOT_ENOUGH_SERVER_MEMORY = 1130;
        public const long ERROR_POSSIBLE_DEADLOCK = 1131;
        public const long ERROR_MAPPED_ALIGNMENT = 1132;
        public const long ERROR_SET_POWER_STATE_VETOED = 1140;
        public const long ERROR_SET_POWER_STATE_FAILED = 1141;
        public const long ERROR_TOO_MANY_LINKS = 1142;
        public const long ERROR_OLD_WIN_VERSION = 1150;
        public const long ERROR_APP_WRONG_OS = 1151;
        public const long ERROR_SINGLE_INSTANCE_APP = 1152;
        public const long ERROR_RMODE_APP = 1153;
        public const long ERROR_INVALID_DLL = 1154;
        public const long ERROR_NO_ASSOCIATION = 1155;
        public const long ERROR_DDE_FAIL = 1156;
        public const long ERROR_DLL_NOT_FOUND = 1157;
        public const long ERROR_NO_MORE_USER_HANDLES = 1158;
        public const long ERROR_MESSAGE_SYNC_ONLY = 1159;
        public const long ERROR_SOURCE_ELEMENT_EMPTY = 1160;
        public const long ERROR_DESTINATION_ELEMENT_FULL = 1161;
        public const long ERROR_ILLEGAL_ELEMENT_ADDRESS = 1162;
        public const long ERROR_MAGAZINE_NOT_PRESENT = 1163;
        public const long ERROR_DEVICE_REINITIALIZATION_NEEDED = 1164;
        public const long ERROR_DEVICE_REQUIRES_CLEANING = 1165;
        public const long ERROR_DEVICE_DOOR_OPEN = 1166;
        public const long ERROR_DEVICE_NOT_CONNECTED = 1167;
        public const long ERROR_NOT_FOUND = 1168;
        public const long ERROR_NO_MATCH = 1169;
        public const long ERROR_SET_NOT_FOUND = 1170;
        public const long ERROR_POINT_NOT_FOUND = 1171;
        public const long ERROR_NO_TRACKING_SERVICE = 1172;
        public const long ERROR_NO_VOLUME_ID = 1173;
        public const long ERROR_UNABLE_TO_REMOVE_REPLACED = 1175;
        public const long ERROR_UNABLE_TO_MOVE_REPLACEMENT = 1176;
        public const long ERROR_UNABLE_TO_MOVE_REPLACEMENT_2 = 1177;
        public const long ERROR_JOURNAL_DELETE_IN_PROGRESS = 1178;
        public const long ERROR_JOURNAL_NOT_ACTIVE = 1179;
        public const long ERROR_POTENTIAL_FILE_FOUND = 1180;
        public const long ERROR_JOURNAL_ENTRY_DELETED = 1181;
        public const long ERROR_BAD_DEVICE = 1200;
        public const long ERROR_CONNECTION_UNAVAIL = 1201;
        public const long ERROR_DEVICE_ALREADY_REMEMBERED = 1202;
        public const long ERROR_NO_NET_OR_BAD_PATH = 1203;
        public const long ERROR_BAD_PROVIDER = 1204;
        public const long ERROR_CANNOT_OPEN_PROFILE = 1205;
        public const long ERROR_BAD_PROFILE = 1206;
        public const long ERROR_NOT_CONTAINER = 1207;
        public const long ERROR_EXTENDED_ERROR = 1208;
        public const long ERROR_INVALID_GROUPNAME = 1209;
        public const long ERROR_INVALID_COMPUTERNAME = 1210;
        public const long ERROR_INVALID_EVENTNAME = 1211;
        public const long ERROR_INVALID_DOMAINNAME = 1212;
        public const long ERROR_INVALID_SERVICENAME = 1213;
        public const long ERROR_INVALID_NETNAME = 1214;
        public const long ERROR_INVALID_SHARENAME = 1215;
        public const long ERROR_INVALID_PASSWORDNAME = 1216;
        public const long ERROR_INVALID_MESSAGENAME = 1217;
        public const long ERROR_INVALID_MESSAGEDEST = 1218;
        public const long ERROR_SESSION_CREDENTIAL_CONFLICT = 1219;
        public const long ERROR_REMOTE_SESSION_LIMIT_EXCEEDED = 1220;
        public const long ERROR_DUP_DOMAINNAME = 1221;
        public const long ERROR_NO_NETWORK = 1222;
        public const long ERROR_CANCELLED = 1223;
        public const long ERROR_USER_MAPPED_FILE = 1224;
        public const long ERROR_CONNECTION_REFUSED = 1225;
        public const long ERROR_GRACEFUL_DISCONNECT = 1226;
        public const long ERROR_ADDRESS_ALREADY_ASSOCIATED = 1227;
        public const long ERROR_ADDRESS_NOT_ASSOCIATED = 1228;
        public const long ERROR_CONNECTION_INVALID = 1229;
        public const long ERROR_CONNECTION_ACTIVE = 1230;
        public const long ERROR_NETWORK_UNREACHABLE = 1231;
        public const long ERROR_HOST_UNREACHABLE = 1232;
        public const long ERROR_PROTOCOL_UNREACHABLE = 1233;
        public const long ERROR_PORT_UNREACHABLE = 1234;
        public const long ERROR_REQUEST_ABORTED = 1235;
        public const long ERROR_CONNECTION_ABORTED = 1236;
        public const long ERROR_RETRY = 1237;
        public const long ERROR_CONNECTION_COUNT_LIMIT = 1238;
        public const long ERROR_LOGIN_TIME_RESTRICTION = 1239;
        public const long ERROR_LOGIN_WKSTA_RESTRICTION = 1240;
        public const long ERROR_INCORRECT_ADDRESS = 1241;
        public const long ERROR_ALREADY_REGISTERED = 1242;
        public const long ERROR_SERVICE_NOT_FOUND = 1243;
        public const long ERROR_NOT_AUTHENTICATED = 1244;
        public const long ERROR_NOT_LOGGED_ON = 1245;
        public const long ERROR_CONTINUE = 1246;
        public const long ERROR_ALREADY_INITIALIZED = 1247;
        public const long ERROR_NO_MORE_DEVICES = 1248;
        public const long ERROR_NO_SUCH_SITE = 1249;
        public const long ERROR_DOMAIN_CONTROLLER_EXISTS = 1250;
        public const long ERROR_ONLY_IF_CONNECTED = 1251;
        public const long ERROR_OVERRIDE_NOCHANGES = 1252;
        public const long ERROR_BAD_USER_PROFILE = 1253;
        public const long ERROR_NOT_SUPPORTED_ON_SBS = 1254;
        public const long ERROR_SERVER_SHUTDOWN_IN_PROGRESS = 1255;
        public const long ERROR_HOST_DOWN = 1256;
        public const long ERROR_NON_ACCOUNT_SID = 1257;
        public const long ERROR_NON_DOMAIN_SID = 1258;
        public const long ERROR_APPHELP_BLOCK = 1259;
        public const long ERROR_ACCESS_DISABLED_BY_POLICY = 1260;
        public const long ERROR_REG_NAT_CONSUMPTION = 1261;
        public const long ERROR_CSCSHARE_OFFLINE = 1262;
        public const long ERROR_PKINIT_FAILURE = 1263;
        public const long ERROR_SMARTCARD_SUBSYSTEM_FAILURE = 1264;
        public const long ERROR_DOWNGRADE_DETECTED = 1265;
        public const long ERROR_MACHINE_LOCKED = 1271;
        public const long ERROR_CALLBACK_SUPPLIED_INVALID_DATA = 1273;
        public const long ERROR_SYNC_FOREGROUND_REFRESH_REQUIRED = 1274;
        public const long ERROR_DRIVER_BLOCKED = 1275;
        public const long ERROR_INVALID_IMPORT_OF_NON_DLL = 1276;
        public const long ERROR_ACCESS_DISABLED_WEBBLADE = 1277;
        public const long ERROR_ACCESS_DISABLED_WEBBLADE_TAMPER = 1278;
        public const long ERROR_RECOVERY_FAILURE = 1279;
        public const long ERROR_ALREADY_FIBER = 1280;
        public const long ERROR_ALREADY_THREAD = 1281;
        public const long ERROR_STACK_BUFFER_OVERRUN = 1282;
        public const long ERROR_PARAMETER_QUOTA_EXCEEDED = 1283;
        public const long ERROR_DEBUGGER_INACTIVE = 1284;
        public const long ERROR_DELAY_LOAD_FAILED = 1285;
        public const long ERROR_VDM_DISALLOWED = 1286;
        public const long ERROR_UNIDENTIFIED_ERROR = 1287;
        public const long ERROR_NOT_ALL_ASSIGNED = 1300;
        public const long ERROR_SOME_NOT_MAPPED = 1301;
        public const long ERROR_NO_QUOTAS_FOR_ACCOUNT = 1302;
        public const long ERROR_LOCAL_USER_SESSION_KEY = 1303;
        public const long ERROR_NULL_LM_PASSWORD = 1304;
        public const long ERROR_UNKNOWN_REVISION = 1305;
        public const long ERROR_REVISION_MISMATCH = 1306;
        public const long ERROR_INVALID_OWNER = 1307;
        public const long ERROR_INVALID_PRIMARY_GROUP = 1308;
        public const long ERROR_NO_IMPERSONATION_TOKEN = 1309;
        public const long ERROR_CANT_DISABLE_MANDATORY = 1310;
        public const long ERROR_NO_LOGON_SERVERS = 1311;
        public const long ERROR_NO_SUCH_LOGON_SESSION = 1312;
        public const long ERROR_NO_SUCH_PRIVILEGE = 1313;
        public const long ERROR_PRIVILEGE_NOT_HELD = 1314;
        public const long ERROR_INVALID_ACCOUNT_NAME = 1315;
        public const long ERROR_USER_EXISTS = 1316;
        public const long ERROR_NO_SUCH_USER = 1317;
        public const long ERROR_GROUP_EXISTS = 1318;
        public const long ERROR_NO_SUCH_GROUP = 1319;
        public const long ERROR_MEMBER_IN_GROUP = 1320;
        public const long ERROR_MEMBER_NOT_IN_GROUP = 1321;
        public const long ERROR_LAST_ADMIN = 1322;
        public const long ERROR_WRONG_PASSWORD = 1323;
        public const long ERROR_ILL_FORMED_PASSWORD = 1324;
        public const long ERROR_PASSWORD_RESTRICTION = 1325;
        public const long ERROR_LOGON_FAILURE = 1326;
        public const long ERROR_ACCOUNT_RESTRICTION = 1327;
        public const long ERROR_INVALID_LOGON_HOURS = 1328;
        public const long ERROR_INVALID_WORKSTATION = 1329;
        public const long ERROR_PASSWORD_EXPIRED = 1330;
        public const long ERROR_ACCOUNT_DISABLED = 1331;
        public const long ERROR_NONE_MAPPED = 1332;
        public const long ERROR_TOO_MANY_LUIDS_REQUESTED = 1333;
        public const long ERROR_LUIDS_EXHAUSTED = 1334;
        public const long ERROR_INVALID_SUB_AUTHORITY = 1335;
        public const long ERROR_INVALID_ACL = 1336;
        public const long ERROR_INVALID_SID = 1337;
        public const long ERROR_INVALID_SECURITY_DESCR = 1338;
        public const long ERROR_BAD_INHERITANCE_ACL = 1340;
        public const long ERROR_SERVER_DISABLED = 1341;
        public const long ERROR_SERVER_NOT_DISABLED = 1342;
        public const long ERROR_INVALID_ID_AUTHORITY = 1343;
        public const long ERROR_ALLOTTED_SPACE_EXCEEDED = 1344;
        public const long ERROR_INVALID_GROUP_ATTRIBUTES = 1345;
        public const long ERROR_BAD_IMPERSONATION_LEVEL = 1346;
        public const long ERROR_CANT_OPEN_ANONYMOUS = 1347;
        public const long ERROR_BAD_VALIDATION_CLASS = 1348;
        public const long ERROR_BAD_TOKEN_TYPE = 1349;
        public const long ERROR_NO_SECURITY_ON_OBJECT = 1350;
        public const long ERROR_CANT_ACCESS_DOMAIN_INFO = 1351;
        public const long ERROR_INVALID_SERVER_STATE = 1352;
        public const long ERROR_INVALID_DOMAIN_STATE = 1353;
        public const long ERROR_INVALID_DOMAIN_ROLE = 1354;
        public const long ERROR_NO_SUCH_DOMAIN = 1355;
        public const long ERROR_DOMAIN_EXISTS = 1356;
        public const long ERROR_DOMAIN_LIMIT_EXCEEDED = 1357;
        public const long ERROR_INTERNAL_DB_CORRUPTION = 1358;
        public const long ERROR_INTERNAL_ERROR = 1359;
        public const long ERROR_GENERIC_NOT_MAPPED = 1360;
        public const long ERROR_BAD_DESCRIPTOR_FORMAT = 1361;
        public const long ERROR_NOT_LOGON_PROCESS = 1362;
        public const long ERROR_LOGON_SESSION_EXISTS = 1363;
        public const long ERROR_NO_SUCH_PACKAGE = 1364;
        public const long ERROR_BAD_LOGON_SESSION_STATE = 1365;
        public const long ERROR_LOGON_SESSION_COLLISION = 1366;
        public const long ERROR_INVALID_LOGON_TYPE = 1367;
        public const long ERROR_CANNOT_IMPERSONATE = 1368;
        public const long ERROR_RXACT_INVALID_STATE = 1369;
        public const long ERROR_RXACT_COMMIT_FAILURE = 1370;
        public const long ERROR_SPECIAL_ACCOUNT = 1371;
        public const long ERROR_SPECIAL_GROUP = 1372;
        public const long ERROR_SPECIAL_USER = 1373;
        public const long ERROR_MEMBERS_PRIMARY_GROUP = 1374;
        public const long ERROR_TOKEN_ALREADY_IN_USE = 1375;
        public const long ERROR_NO_SUCH_ALIAS = 1376;
        public const long ERROR_MEMBER_NOT_IN_ALIAS = 1377;
        public const long ERROR_MEMBER_IN_ALIAS = 1378;
        public const long ERROR_ALIAS_EXISTS = 1379;
        public const long ERROR_LOGON_NOT_GRANTED = 1380;
        public const long ERROR_TOO_MANY_SECRETS = 1381;
        public const long ERROR_SECRET_TOO_LONG = 1382;
        public const long ERROR_INTERNAL_DB_ERROR = 1383;
        public const long ERROR_TOO_MANY_CONTEXT_IDS = 1384;
        public const long ERROR_LOGON_TYPE_NOT_GRANTED = 1385;
        public const long ERROR_NT_CROSS_ENCRYPTION_REQUIRED = 1386;
        public const long ERROR_NO_SUCH_MEMBER = 1387;
        public const long ERROR_INVALID_MEMBER = 1388;
        public const long ERROR_TOO_MANY_SIDS = 1389;
        public const long ERROR_LM_CROSS_ENCRYPTION_REQUIRED = 1390;
        public const long ERROR_NO_INHERITANCE = 1391;
        public const long ERROR_FILE_CORRUPT = 1392;
        public const long ERROR_DISK_CORRUPT = 1393;
        public const long ERROR_NO_USER_SESSION_KEY = 1394;
        public const long ERROR_LICENSE_QUOTA_EXCEEDED = 1395;
        public const long ERROR_WRONG_TARGET_NAME = 1396;
        public const long ERROR_MUTUAL_AUTH_FAILED = 1397;
        public const long ERROR_TIME_SKEW = 1398;
        public const long ERROR_CURRENT_DOMAIN_NOT_ALLOWED = 1399;
        public const long ERROR_INVALID_WINDOW_HANDLE = 1400;
        public const long ERROR_INVALID_MENU_HANDLE = 1401;
        public const long ERROR_INVALID_CURSOR_HANDLE = 1402;
        public const long ERROR_INVALID_ACCEL_HANDLE = 1403;
        public const long ERROR_INVALID_HOOK_HANDLE = 1404;
        public const long ERROR_INVALID_DWP_HANDLE = 1405;
        public const long ERROR_TLW_WITH_WSCHILD = 1406;
        public const long ERROR_CANNOT_FIND_WND_CLASS = 1407;
        public const long ERROR_WINDOW_OF_OTHER_THREAD = 1408;
        public const long ERROR_HOTKEY_ALREADY_REGISTERED = 1409;
        public const long ERROR_CLASS_ALREADY_EXISTS = 1410;
        public const long ERROR_CLASS_DOES_NOT_EXIST = 1411;
        public const long ERROR_CLASS_HAS_WINDOWS = 1412;
        public const long ERROR_INVALID_INDEX = 1413;
        public const long ERROR_INVALID_ICON_HANDLE = 1414;
        public const long ERROR_PRIVATE_DIALOG_INDEX = 1415;
        public const long ERROR_LISTBOX_ID_NOT_FOUND = 1416;
        public const long ERROR_NO_WILDCARD_CHARACTERS = 1417;
        public const long ERROR_CLIPBOARD_NOT_OPEN = 1418;
        public const long ERROR_HOTKEY_NOT_REGISTERED = 1419;
        public const long ERROR_WINDOW_NOT_DIALOG = 1420;
        public const long ERROR_CONTROL_ID_NOT_FOUND = 1421;
        public const long ERROR_INVALID_COMBOBOX_MESSAGE = 1422;
        public const long ERROR_WINDOW_NOT_COMBOBOX = 1423;
        public const long ERROR_INVALID_EDIT_HEIGHT = 1424;
        public const long ERROR_DC_NOT_FOUND = 1425;
        public const long ERROR_INVALID_HOOK_FILTER = 1426;
        public const long ERROR_INVALID_FILTER_PROC = 1427;
        public const long ERROR_HOOK_NEEDS_HMOD = 1428;
        public const long ERROR_GLOBAL_ONLY_HOOK = 1429;
        public const long ERROR_JOURNAL_HOOK_SET = 1430;
        public const long ERROR_HOOK_NOT_INSTALLED = 1431;
        public const long ERROR_INVALID_LB_MESSAGE = 1432;
        public const long ERROR_SETCOUNT_ON_BAD_LB = 1433;
        public const long ERROR_LB_WITHOUT_TABSTOPS = 1434;
        public const long ERROR_DESTROY_OBJECT_OF_OTHER_THREAD = 1435;
        public const long ERROR_CHILD_WINDOW_MENU = 1436;
        public const long ERROR_NO_SYSTEM_MENU = 1437;
        public const long ERROR_INVALID_MSGBOX_STYLE = 1438;
        public const long ERROR_INVALID_SPI_VALUE = 1439;
        public const long ERROR_SCREEN_ALREADY_LOCKED = 1440;
        public const long ERROR_HWNDS_HAVE_DIFF_PARENT = 1441;
        public const long ERROR_NOT_CHILD_WINDOW = 1442;
        public const long ERROR_INVALID_GW_COMMAND = 1443;
        public const long ERROR_INVALID_THREAD_ID = 1444;
        public const long ERROR_NON_MDICHILD_WINDOW = 1445;
        public const long ERROR_POPUP_ALREADY_ACTIVE = 1446;
        public const long ERROR_NO_SCROLLBARS = 1447;
        public const long ERROR_INVALID_SCROLLBAR_RANGE = 1448;
        public const long ERROR_INVALID_SHOWWIN_COMMAND = 1449;
        public const long ERROR_NO_SYSTEM_RESOURCES = 1450;
        public const long ERROR_NONPAGED_SYSTEM_RESOURCES = 1451;
        public const long ERROR_PAGED_SYSTEM_RESOURCES = 1452;
        public const long ERROR_WORKING_SET_QUOTA = 1453;
        public const long ERROR_PAGEFILE_QUOTA = 1454;
        public const long ERROR_COMMITMENT_LIMIT = 1455;
        public const long ERROR_MENU_ITEM_NOT_FOUND = 1456;
        public const long ERROR_INVALID_KEYBOARD_HANDLE = 1457;
        public const long ERROR_HOOK_TYPE_NOT_ALLOWED = 1458;
        public const long ERROR_REQUIRES_INTERACTIVE_WINDOWSTATION = 1459;
        public const long ERROR_TIMEOUT = 1460;
        public const long ERROR_INVALID_MONITOR_HANDLE = 1461;
        public const long ERROR_INCORRECT_SIZE = 1462;
        public const long ERROR_EVENTLOG_FILE_CORRUPT = 1500;
        public const long ERROR_EVENTLOG_CANT_START = 1501;
        public const long ERROR_LOG_FILE_FULL = 1502;
        public const long ERROR_EVENTLOG_FILE_CHANGED = 1503;
        public const long ERROR_INSTALL_SERVICE_FAILURE = 1601;
        public const long ERROR_INSTALL_USEREXIT = 1602;
        public const long ERROR_INSTALL_FAILURE = 1603;
        public const long ERROR_INSTALL_SUSPEND = 1604;
        public const long ERROR_UNKNOWN_PRODUCT = 1605;
        public const long ERROR_UNKNOWN_FEATURE = 1606;
        public const long ERROR_UNKNOWN_COMPONENT = 1607;
        public const long ERROR_UNKNOWN_PROPERTY = 1608;
        public const long ERROR_INVALID_HANDLE_STATE = 1609;
        public const long ERROR_BAD_CONFIGURATION = 1610;
        public const long ERROR_INDEX_ABSENT = 1611;
        public const long ERROR_INSTALL_SOURCE_ABSENT = 1612;
        public const long ERROR_INSTALL_PACKAGE_VERSION = 1613;
        public const long ERROR_PRODUCT_UNINSTALLED = 1614;
        public const long ERROR_BAD_QUERY_SYNTAX = 1615;
        public const long ERROR_INVALID_FIELD = 1616;
        public const long ERROR_DEVICE_REMOVED = 1617;
        public const long ERROR_INSTALL_ALREADY_RUNNING = 1618;
        public const long ERROR_INSTALL_PACKAGE_OPEN_FAILED = 1619;
        public const long ERROR_INSTALL_PACKAGE_INVALID = 1620;
        public const long ERROR_INSTALL_UI_FAILURE = 1621;
        public const long ERROR_INSTALL_LOG_FAILURE = 1622;
        public const long ERROR_INSTALL_LANGUAGE_UNSUPPORTED = 1623;
        public const long ERROR_INSTALL_TRANSFORM_FAILURE = 1624;
        public const long ERROR_INSTALL_PACKAGE_REJECTED = 1625;
        public const long ERROR_FUNCTION_NOT_CALLED = 1626;
        public const long ERROR_FUNCTION_FAILED = 1627;
        public const long ERROR_INVALID_TABLE = 1628;
        public const long ERROR_DATATYPE_MISMATCH = 1629;
        public const long ERROR_UNSUPPORTED_TYPE = 1630;
        public const long ERROR_CREATE_FAILED = 1631;
        public const long ERROR_INSTALL_TEMP_UNWRITABLE = 1632;
        public const long ERROR_INSTALL_PLATFORM_UNSUPPORTED = 1633;
        public const long ERROR_INSTALL_NOTUSED = 1634;
        public const long ERROR_PATCH_PACKAGE_OPEN_FAILED = 1635;
        public const long ERROR_PATCH_PACKAGE_INVALID = 1636;
        public const long ERROR_PATCH_PACKAGE_UNSUPPORTED = 1637;
        public const long ERROR_PRODUCT_VERSION = 1638;
        public const long ERROR_INVALID_COMMAND_LINE = 1639;
        public const long ERROR_INSTALL_REMOTE_DISALLOWED = 1640;
        public const long ERROR_SUCCESS_REBOOT_INITIATED = 1641;
        public const long ERROR_PATCH_TARGET_NOT_FOUND = 1642;
        public const long ERROR_PATCH_PACKAGE_REJECTED = 1643;
        public const long ERROR_INSTALL_TRANSFORM_REJECTED = 1644;
        public const long ERROR_INSTALL_REMOTE_PROHIBITED = 1645;
        public const long ERROR_ONLY_ONE_SIM = 1646;
        public const long WSAEINTR = 10004;
        public const long WSAEBADF = 10009;
        public const long WSAEACCES = 10013;
        public const long WSAEFAULT = 10014;
        public const long WSAEINVAL = 10022;
        public const long WSAEMFILE = 10024;
        public const long WSAEWOULDBLOCK = 10035;
        public const long WSAEINPROGRESS = 10036;
        public const long WSAEALREADY = 10037;
        public const long WSAENOTSOCK = 10038;
        public const long WSAEDESTADDRREQ = 10039;
        public const long WSAEMSGSIZE = 10040;
        public const long WSAEPROTOTYPE = 10041;
        public const long WSAENOPROTOOPT = 10042;
        public const long WSAEPROTONOSUPPORT = 10043;
        public const long WSAESOCKTNOSUPPORT = 10044;
        public const long WSAEOPNOTSUPP = 10045;
        public const long WSAEPFNOSUPPORT = 10046;
        public const long WSAEAFNOSUPPORT = 10047;
        public const long WSAEADDRINUSE = 10048;
        public const long WSAEADDRNOTAVAIL = 10049;
        public const long WSAENETDOWN = 10050;
        public const long WSAENETUNREACH = 10051;
        public const long WSAENETRESET = 10052;
        public const long WSAECONNABORTED = 10053;
        public const long WSAECONNRESET = 10054;
        public const long WSAENOBUFS = 10055;
        public const long WSAEISCONN = 10056;
        public const long WSAENOTCONN = 10057;
        public const long WSAESHUTDOWN = 10058;
        public const long WSAETOOMANYREFS = 10059;
        public const long WSAETIMEDOUT = 10060;
        public const long WSAECONNREFUSED = 10061;
        public const long WSAELOOP = 10062;
        public const long WSAENAMETOOLONG = 10063;
        public const long WSAEHOSTDOWN = 10064;
        public const long WSAEHOSTUNREACH = 10065;
        public const long WSAENOTEMPTY = 10066;
        public const long WSAEPROCLIM = 10067;
        public const long WSAEUSERS = 10068;
        public const long WSAEDQUOT = 10069;
        public const long WSAESTALE = 10070;
        public const long WSAEREMOTE = 10071;
        public const long WSASYSNOTREADY = 10091;
        public const long WSAVERNOTSUPPORTED = 10092;
        public const long WSANOTINITIALISED = 10093;
        public const long WSAEDISCON = 10101;
        public const long WSAENOMORE = 10102;
        public const long WSAECANCELLED = 10103;
        public const long WSAEINVALIDPROCTABLE = 10104;
        public const long WSAEINVALIDPROVIDER = 10105;
        public const long WSAEPROVIDERFAILEDINIT = 10106;
        public const long WSASYSCALLFAILURE = 10107;
        public const long WSASERVICE_NOT_FOUND = 10108;
        public const long WSATYPE_NOT_FOUND = 10109;
        public const long WSA_E_NO_MORE = 10110;
        public const long WSA_E_CANCELLED = 10111;
        public const long WSAEREFUSED = 10112;
        public const long WSAHOST_NOT_FOUND = 11001;
        public const long WSATRY_AGAIN = 11002;
        public const long WSANO_RECOVERY = 11003;
        public const long WSANO_DATA = 11004;
        public const long WSA_QOS_RECEIVERS = 11005;
        public const long WSA_QOS_SENDERS = 11006;
        public const long WSA_QOS_NO_SENDERS = 11007;
        public const long WSA_QOS_NO_RECEIVERS = 11008;
        public const long WSA_QOS_REQUEST_CONFIRMED = 11009;
        public const long WSA_QOS_ADMISSION_FAILURE = 11010;
        public const long WSA_QOS_POLICY_FAILURE = 11011;
        public const long WSA_QOS_BAD_STYLE = 11012;
        public const long WSA_QOS_BAD_OBJECT = 11013;
        public const long WSA_QOS_TRAFFIC_CTRL_ERROR = 11014;
        public const long WSA_QOS_GENERIC_ERROR = 11015;
        public const long WSA_QOS_ESERVICETYPE = 11016;
        public const long WSA_QOS_EFLOWSPEC = 11017;
        public const long WSA_QOS_EPROVSPECBUF = 11018;
        public const long WSA_QOS_EFILTERSTYLE = 11019;
        public const long WSA_QOS_EFILTERTYPE = 11020;
        public const long WSA_QOS_EFILTERCOUNT = 11021;
        public const long WSA_QOS_EOBJLENGTH = 11022;
        public const long WSA_QOS_EFLOWCOUNT = 11023;
        public const long WSA_QOS_EUNKOWNPSOBJ = 11024;
        public const long WSA_QOS_EPOLICYOBJ = 11025;
        public const long WSA_QOS_EFLOWDESC = 11026;
        public const long WSA_QOS_EPSFLOWSPEC = 11027;
        public const long WSA_QOS_EPSFILTERSPEC = 11028;
        public const long WSA_QOS_ESDMODEOBJ = 11029;
        public const long WSA_QOS_ESHAPERATEOBJ = 11030;
        public const long WSA_QOS_RESERVED_PETYPE = 11031;
        public const long SE_ERR_TOOL_FUNC_NOT_SUPPORT = 50103;
        public const long SE_ERR_INSUFFICIENCY_IMAGE = 50109;
        public const long SE_ERR_SUT_INTERNAL_ERROR = 50701;
        public const long SE_ERR_SUT_PHONE_KEY_ACCESS_FAIL = 50702;
        public const long SE_ERR_SUT_DEVICE_MODE_NOT_SUPPORT = 50703;
        public const long SE_ERR_SUT_DEVICE_INSTANCE_FAIL = 50704;
        public const long SE_ERR_SUT_BATT_LEVEL_TOO_LOW = 50705;
        public const long SE_ERR_SUT_CHECK_SW_IMAGE_FAIL = 50706;
        public const long SE_ERR_SUT_PARSE_INFO_FAIL = 50707;
        public const long SE_ERR_SUT_COMMAND_FAIL = 50708;
        public const long SE_ERR_SUT_INVALID_PARAMS = 50709;
        public const long SE_ERR_SUT_OBSOLETE_IMAGE = 50710;
        public const long SE_ERR_SUT_ERROR_SIG_IMAGE = 50711;
        public const long SE_ERR_SUT_NOT_ALLOW_DOWNGRADE = 50712;
        public const long SE_ERR_SUT_FLASH_CAPACITY_NOT_MATCH = 50713;
        public const long SE_ERR_SUT_CREATE_CUST_IMAGE_FAIL = 50714;
        public const long SE_ERR_SUT_DETECT_EMMC_DISK_FAIL = 50715;
        public const long SE_ERR_SUT_SWITCH_DEVICE_MODE_FAIL = 50716;
        public const long SE_ERR_SUT_INVALID_IMAGE_PATH = 50717;
        public const long SE_ERR_SUT_INVALID_IMAGE_FORMAT = 50718;
        public const long SE_ERR_SUT_ACCESS_IMAGE_PATH = 50719;
        public const long SE_ERR_SUT_BCT_OR_PT_MISSED = 51003;
        public const long SE_ERR_SUT_HANDLE_RSD_LITE = 50721;
        public const long SE_ERR_SUT_SECURITY_DENY = 50723;
        public const long SE_ERR_SUT_UNKNOWN_OPTION = 50725;
        public const long SE_ERR_SUT_AUTHENTICATION = 50726;
        public const long SE_ERR_SCSI_INVALID_PARAMS = 50301;
        public const long SE_ERR_SCSI_INTERNAL_ERROR = 50302;
        public const long SE_ERR_SCSI_DEVICE_NOT_OPENED = 50303;
        public const long SE_ERR_SCSI_OPEN_DEVICE_FAIL = 50304;
        public const long SE_ERR_SCSI_SEND_COMMAND_FAIL = 50305;
        public const long SE_ERR_SCSI_MISMATCH_RESPONSE = 50306;
        public const long SE_ERR_SCSI_NO_SD_CARD = 50307;
        public const long SE_ERR_SD_NO_ENOUGH_SPACE = 50308;
        public const long SE_ERR_ACCESS_DEVICE_DENIED = 50309;
        public const long SW_ERR_TOOL_REQUIRE_DOT_NET_FRAMEWORK40 = 51201;
        public const long SW_ERR_ROCKEY_CHECK_ROCKEY_FAIL = 51301;
        public const long SW_ERR_ROCKEY_NON_PERMISSION = 51303;
        public const long SW_ERR_SIM_LOCK_UNKNWON_FUNC_TYPE = 51601;
        public const long SW_ERR_SIM_LOCK_GET_STATUS_FAIL = 51602;
        public const long SW_ERR_SIM_LOCK_DO_LOCK_FAIL = 51603;
        public const long SW_ERR_SIM_LOCK_DO_UNLOCK_FAIL = 51604;

        public static string StringOf(long value)
        {
            switch (value)
            {
                case 0:
                    return "SUCCESS";
                case 1:
                    return "ERROR_INVALID_FUNCTION";
                case 2:
                    return "ERROR_FILE_NOT_FOUND";
                case 3:
                    return "ERROR_PATH_NOT_FOUND";
                case 4:
                    return "ERROR_TOO_MANY_OPEN_FILES";
                case 5:
                    return "ERROR_ACCESS_DENIED";
                case 6:
                    return "ERROR_INVALID_HANDLE";
                case 7:
                    return "ERROR_ARENA_TRASHED";
                case 8:
                    return "ERROR_NOT_ENOUGH_MEMORY";
                case 9:
                    return "ERROR_INVALID_BLOCK";
                case 10:
                    return "ERROR_BAD_ENVIRONMENT";
                case 11:
                    return "ERROR_BAD_FORMAT";
                case 12:
                    return "ERROR_INVALID_ACCESS";
                case 13:
                    return "ERROR_INVALID_DATA";
                case 14:
                    return "ERROR_OUTOFMEMORY";
                case 15:
                    return "ERROR_INVALID_DRIVE";
                case 16:
                    return "ERROR_CURRENT_DIRECTORY";
                case 17:
                    return "ERROR_NOT_SAME_DEVICE";
                case 18:
                    return "ERROR_NO_MORE_FILES";
                case 19:
                    return "ERROR_WRITE_PROTECT";
                case 20:
                    return "ERROR_BAD_UNIT";
                case 21:
                    return "ERROR_NOT_READY";
                case 22:
                    return "ERROR_BAD_COMMAND";
                case 23:
                    return "ERROR_CRC";
                case 24:
                    return "ERROR_BAD_LENGTH";
                case 25:
                    return "ERROR_SEEK";
                case 26:
                    return "ERROR_NOT_DOS_DISK";
                case 27:
                    return "ERROR_SECTOR_NOT_FOUND";
                case 28:
                    return "ERROR_OUT_OF_PAPER";
                case 29:
                    return "ERROR_WRITE_FAULT";
                case 30:
                    return "ERROR_READ_FAULT";
                case 31:
                    return "ERROR_GEN_FAILURE";
                case 32:
                    return "ERROR_SHARING_VIOLATION";
                case 33:
                    return "ERROR_LOCK_VIOLATION";
                case 34:
                    return "ERROR_WRONG_DISK";
                case 36:
                    return "ERROR_SHARING_BUFFER_EXCEEDED";
                case 38:
                    return "ERROR_HANDLE_EOF";
                case 39:
                    return "ERROR_HANDLE_DISK_FULL";
                case 50:
                    return "ERROR_NOT_SUPPORTED";
                case 51:
                    return "ERROR_REM_NOT_LIST";
                case 52:
                    return "ERROR_DUP_NAME";
                case 53:
                    return "ERROR_BAD_NETPATH";
                case 54:
                    return "ERROR_NETWORK_BUSY";
                case 55:
                    return "ERROR_DEV_NOT_EXIST";
                case 56:
                    return "ERROR_TOO_MANY_CMDS";
                case 57:
                    return "ERROR_ADAP_HDW_ERR";
                case 58:
                    return "ERROR_BAD_NET_RESP";
                case 59:
                    return "ERROR_UNEXP_NET_ERR";
                case 60:
                    return "ERROR_BAD_REM_ADAP";
                case 61:
                    return "ERROR_PRINTQ_FULL";
                case 62:
                    return "ERROR_NO_SPOOL_SPACE";
                case 63:
                    return "ERROR_PRINT_CANCELLED";
                case 64:
                    return "ERROR_NETNAME_DELETED";
                case 65:
                    return "ERROR_NETWORK_ACCESS_DENIED";
                case 66:
                    return "ERROR_BAD_DEV_TYPE";
                case 67:
                    return "ERROR_BAD_NET_NAME";
                case 68:
                    return "ERROR_TOO_MANY_NAMES";
                case 69:
                    return "ERROR_TOO_MANY_SESS";
                case 70:
                    return "ERROR_SHARING_PAUSED";
                case 71:
                    return "ERROR_REQ_NOT_ACCEP";
                case 72:
                    return "ERROR_REDIR_PAUSED";
                case 80:
                    return "ERROR_FILE_EXISTS";
                case 82:
                    return "ERROR_CANNOT_MAKE";
                case 83:
                    return "ERROR_FAIL_I24";
                case 84:
                    return "ERROR_OUT_OF_STRUCTURES";
                case 85:
                    return "ERROR_ALREADY_ASSIGNED";
                case 86:
                    return "ERROR_INVALID_PASSWORD";
                case 87:
                    return "ERROR_INVALID_PARAMETER";
                case 88:
                    return "ERROR_NET_WRITE_FAULT";
                case 89:
                    return "ERROR_NO_PROC_SLOTS";
                case 100:
                    return "ERROR_TOO_MANY_SEMAPHORES";
                case 101:
                    return "ERROR_EXCL_SEM_ALREADY_OWNED";
                case 102:
                    return "ERROR_SEM_IS_SET";
                case 103:
                    return "ERROR_TOO_MANY_SEM_REQUESTS";
                case 104:
                    return "ERROR_INVALID_AT_INTERRUPT_TIME";
                case 105:
                    return "ERROR_SEM_OWNER_DIED";
                case 106:
                    return "ERROR_SEM_USER_LIMIT";
                case 107:
                    return "ERROR_DISK_CHANGE";
                case 108:
                    return "ERROR_DRIVE_LOCKED";
                case 109:
                    return "ERROR_BROKEN_PIPE";
                case 110:
                    return "ERROR_OPEN_FAILED";
                case 111:
                    return "ERROR_BUFFER_OVERFLOW";
                case 112:
                    return "ERROR_DISK_FULL";
                case 113:
                    return "ERROR_NO_MORE_SEARCH_HANDLES";
                case 114:
                    return "ERROR_INVALID_TARGET_HANDLE";
                case 117:
                    return "ERROR_INVALID_CATEGORY";
                case 118:
                    return "ERROR_INVALID_VERIFY_SWITCH";
                case 119:
                    return "ERROR_BAD_DRIVER_LEVEL";
                case 120:
                    return "ERROR_CALL_NOT_IMPLEMENTED";
                case 121:
                    return "ERROR_SEM_TIMEOUT";
                case 122:
                    return "ERROR_INSUFFICIENT_BUFFER";
                case 123:
                    return "ERROR_INVALID_NAME";
                case 124:
                    return "ERROR_INVALID_LEVEL";
                case 125:
                    return "ERROR_NO_VOLUME_LABEL";
                case 126:
                    return "ERROR_MOD_NOT_FOUND";
                case (long)sbyte.MaxValue:
                    return "ERROR_PROC_NOT_FOUND";
                case 128:
                    return "ERROR_WAIT_NO_CHILDREN";
                case 129:
                    return "ERROR_CHILD_NOT_COMPLETE";
                case 130:
                    return "ERROR_DIRECT_ACCESS_HANDLE";
                case 131:
                    return "ERROR_NEGATIVE_SEEK";
                case 132:
                    return "ERROR_SEEK_ON_DEVICE";
                case 133:
                    return "ERROR_IS_JOIN_TARGET";
                case 134:
                    return "ERROR_IS_JOINED";
                case 135:
                    return "ERROR_IS_SUBSTED";
                case 136:
                    return "ERROR_NOT_JOINED";
                case 137:
                    return "ERROR_NOT_SUBSTED";
                case 138:
                    return "ERROR_JOIN_TO_JOIN";
                case 139:
                    return "ERROR_SUBST_TO_SUBST";
                case 140:
                    return "ERROR_JOIN_TO_SUBST";
                case 141:
                    return "ERROR_SUBST_TO_JOIN";
                case 142:
                    return "ERROR_BUSY_DRIVE";
                case 143:
                    return "ERROR_SAME_DRIVE";
                case 144:
                    return "ERROR_DIR_NOT_ROOT";
                case 145:
                    return "ERROR_DIR_NOT_EMPTY";
                case 146:
                    return "ERROR_IS_SUBST_PATH";
                case 147:
                    return "ERROR_IS_JOIN_PATH";
                case 148:
                    return "ERROR_PATH_BUSY";
                case 149:
                    return "ERROR_IS_SUBST_TARGET";
                case 150:
                    return "ERROR_SYSTEM_TRACE";
                case 151:
                    return "ERROR_INVALID_EVENT_COUNT";
                case 152:
                    return "ERROR_TOO_MANY_MUXWAITERS";
                case 153:
                    return "ERROR_INVALID_LIST_FORMAT";
                case 154:
                    return "ERROR_LABEL_TOO_LONG";
                case 155:
                    return "ERROR_TOO_MANY_TCBS";
                case 156:
                    return "ERROR_SIGNAL_REFUSED";
                case 157:
                    return "ERROR_DISCARDED";
                case 158:
                    return "ERROR_NOT_LOCKED";
                case 159:
                    return "ERROR_BAD_THREADID_ADDR";
                case 160:
                    return "ERROR_BAD_ARGUMENTS";
                case 161:
                    return "ERROR_BAD_PATHNAME";
                case 162:
                    return "ERROR_SIGNAL_PENDING";
                case 164:
                    return "ERROR_MAX_THRDS_REACHED";
                case 167:
                    return "ERROR_LOCK_FAILED";
                case 170:
                    return "ERROR_BUSY";
                case 173:
                    return "ERROR_CANCEL_VIOLATION";
                case 174:
                    return "ERROR_ATOMIC_LOCKS_NOT_SUPPORTED";
                case 180:
                    return "ERROR_INVALID_SEGMENT_NUMBER";
                case 182:
                    return "ERROR_INVALID_ORDINAL";
                case 183:
                    return "ERROR_ALREADY_EXISTS";
                case 186:
                    return "ERROR_INVALID_FLAG_NUMBER";
                case 187:
                    return "ERROR_SEM_NOT_FOUND";
                case 188:
                    return "ERROR_INVALID_STARTING_CODESEG";
                case 189:
                    return "ERROR_INVALID_STACKSEG";
                case 190:
                    return "ERROR_INVALID_MODULETYPE";
                case 191:
                    return "ERROR_INVALID_EXE_SIGNATURE";
                case 192:
                    return "ERROR_EXE_MARKED_INVALID";
                case 193:
                    return "ERROR_BAD_EXE_FORMAT";
                case 194:
                    return "ERROR_ITERATED_DATA_EXCEEDS_64k";
                case 195:
                    return "ERROR_INVALID_MINALLOCSIZE";
                case 196:
                    return "ERROR_DYNLINK_FROM_INVALID_RING";
                case 197:
                    return "ERROR_IOPL_NOT_ENABLED";
                case 198:
                    return "ERROR_INVALID_SEGDPL";
                case 199:
                    return "ERROR_AUTODATASEG_EXCEEDS_64k";
                case 200:
                    return "ERROR_RING2SEG_MUST_BE_MOVABLE";
                case 201:
                    return "ERROR_RELOC_CHAIN_XEEDS_SEGLIM";
                case 202:
                    return "ERROR_INFLOOP_IN_RELOC_CHAIN";
                case 203:
                    return "ERROR_ENVVAR_NOT_FOUND";
                case 205:
                    return "ERROR_NO_SIGNAL_SENT";
                case 206:
                    return "ERROR_FILENAME_EXCED_RANGE";
                case 207:
                    return "ERROR_RING2_STACK_IN_USE";
                case 208:
                    return "ERROR_META_EXPANSION_TOO_LONG";
                case 209:
                    return "ERROR_INVALID_SIGNAL_NUMBER";
                case 210:
                    return "ERROR_THREAD_1_INACTIVE";
                case 212:
                    return "ERROR_LOCKED";
                case 214:
                    return "ERROR_TOO_MANY_MODULES";
                case 215:
                    return "ERROR_NESTING_NOT_ALLOWED";
                case 216:
                    return "ERROR_EXE_MACHINE_TYPE_MISMATCH";
                case 217:
                    return "ERROR_EXE_CANNOT_MODIFY_SIGNED_BINARY";
                case 218:
                    return "ERROR_EXE_CANNOT_MODIFY_STRONG_SIGNED_BINARY";
                case 230:
                    return "ERROR_BAD_PIPE";
                case 231:
                    return "ERROR_PIPE_BUSY";
                case 232:
                    return "ERROR_NO_DATA";
                case 233:
                    return "ERROR_PIPE_NOT_CONNECTED";
                case 234:
                    return "ERROR_MORE_DATA";
                case 240:
                    return "ERROR_VC_DISCONNECTED";
                case 254:
                    return "ERROR_INVALID_EA_NAME";
                case (long)byte.MaxValue:
                    return "ERROR_EA_LIST_INCONSISTENT";
                case 258:
                    return "WAIT_TIMEOUT";
                case 259:
                    return "ERROR_NO_MORE_ITEMS";
                case 266:
                    return "ERROR_CANNOT_COPY";
                case 267:
                    return "ERROR_DIRECTORY";
                case 275:
                    return "ERROR_EAS_DIDNT_FIT";
                case 276:
                    return "ERROR_EA_FILE_CORRUPT";
                case 277:
                    return "ERROR_EA_TABLE_FULL";
                case 278:
                    return "ERROR_INVALID_EA_HANDLE";
                case 282:
                    return "ERROR_EAS_NOT_SUPPORTED";
                case 288:
                    return "ERROR_NOT_OWNER";
                case 298:
                    return "ERROR_TOO_MANY_POSTS";
                case 299:
                    return "ERROR_PARTIAL_COPY";
                case 300:
                    return "ERROR_OPLOCK_NOT_GRANTED";
                case 301:
                    return "ERROR_INVALID_OPLOCK_PROTOCOL";
                case 302:
                    return "ERROR_DISK_TOO_FRAGMENTED";
                case 303:
                    return "ERROR_DELETE_PENDING";
                case 317:
                    return "ERROR_MR_MID_NOT_FOUND";
                case 318:
                    return "ERROR_SCOPE_NOT_FOUND";
                case 487:
                    return "ERROR_INVALID_ADDRESS";
                case 534:
                    return "ERROR_ARITHMETIC_OVERFLOW";
                case 535:
                    return "ERROR_PIPE_CONNECTED";
                case 536:
                    return "ERROR_PIPE_LISTENING";
                case 994:
                    return "ERROR_EA_ACCESS_DENIED";
                case 995:
                    return "ERROR_OPERATION_ABORTED";
                case 996:
                    return "ERROR_IO_INCOMPLETE";
                case 997:
                    return "ERROR_IO_PENDING";
                case 998:
                    return "ERROR_NOACCESS";
                case 999:
                    return "ERROR_SWAPERROR";
                case 1001:
                    return "ERROR_STACK_OVERFLOW";
                case 1002:
                    return "ERROR_INVALID_MESSAGE";
                case 1003:
                    return "ERROR_CAN_NOT_COMPLETE";
                case 1004:
                    return "ERROR_INVALID_FLAGS";
                case 1005:
                    return "ERROR_UNRECOGNIZED_VOLUME";
                case 1006:
                    return "ERROR_FILE_INVALID";
                case 1007:
                    return "ERROR_FULLSCREEN_MODE";
                case 1008:
                    return "ERROR_NO_TOKEN";
                case 1009:
                    return "ERROR_BADDB";
                case 1010:
                    return "ERROR_BADKEY";
                case 1011:
                    return "ERROR_CANTOPEN";
                case 1012:
                    return "ERROR_CANTREAD";
                case 1013:
                    return "ERROR_CANTWRITE";
                case 1014:
                    return "ERROR_REGISTRY_RECOVERED";
                case 1015:
                    return "ERROR_REGISTRY_CORRUPT";
                case 1016:
                    return "ERROR_REGISTRY_IO_FAILED";
                case 1017:
                    return "ERROR_NOT_REGISTRY_FILE";
                case 1018:
                    return "ERROR_KEY_DELETED";
                case 1019:
                    return "ERROR_NO_LOG_SPACE";
                case 1020:
                    return "ERROR_KEY_HAS_CHILDREN";
                case 1021:
                    return "ERROR_CHILD_MUST_BE_VOLATILE";
                case 1022:
                    return "ERROR_NOTIFY_ENUM_DIR";
                case 1051:
                    return "ERROR_DEPENDENT_SERVICES_RUNNING";
                case 1052:
                    return "ERROR_INVALID_SERVICE_CONTROL";
                case 1053:
                    return "ERROR_SERVICE_REQUEST_TIMEOUT";
                case 1054:
                    return "ERROR_SERVICE_NO_THREAD";
                case 1055:
                    return "ERROR_SERVICE_DATABASE_LOCKED";
                case 1056:
                    return "ERROR_SERVICE_ALREADY_RUNNING";
                case 1057:
                    return "ERROR_INVALID_SERVICE_ACCOUNT";
                case 1058:
                    return "ERROR_SERVICE_DISABLED";
                case 1059:
                    return "ERROR_CIRCULAR_DEPENDENCY";
                case 1060:
                    return "ERROR_SERVICE_DOES_NOT_EXIST";
                case 1061:
                    return "ERROR_SERVICE_CANNOT_ACCEPT_CTRL";
                case 1062:
                    return "ERROR_SERVICE_NOT_ACTIVE";
                case 1063:
                    return "ERROR_FAILED_SERVICE_CONTROLLER_CONNECT";
                case 1064:
                    return "ERROR_EXCEPTION_IN_SERVICE";
                case 1065:
                    return "ERROR_DATABASE_DOES_NOT_EXIST";
                case 1066:
                    return "ERROR_SERVICE_SPECIFIC_ERROR";
                case 1067:
                    return "ERROR_PROCESS_ABORTED";
                case 1068:
                    return "ERROR_SERVICE_DEPENDENCY_FAIL";
                case 1069:
                    return "ERROR_SERVICE_LOGON_FAILED";
                case 1070:
                    return "ERROR_SERVICE_START_HANG";
                case 1071:
                    return "ERROR_INVALID_SERVICE_LOCK";
                case 1072:
                    return "ERROR_SERVICE_MARKED_FOR_DELETE";
                case 1073:
                    return "ERROR_SERVICE_EXISTS";
                case 1074:
                    return "ERROR_ALREADY_RUNNING_LKG";
                case 1075:
                    return "ERROR_SERVICE_DEPENDENCY_DELETED";
                case 1076:
                    return "ERROR_BOOT_ALREADY_ACCEPTED";
                case 1077:
                    return "ERROR_SERVICE_NEVER_STARTED";
                case 1078:
                    return "ERROR_DUPLICATE_SERVICE_NAME";
                case 1079:
                    return "ERROR_DIFFERENT_SERVICE_ACCOUNT";
                case 1080:
                    return "ERROR_CANNOT_DETECT_DRIVER_FAILURE";
                case 1081:
                    return "ERROR_CANNOT_DETECT_PROCESS_ABORT";
                case 1082:
                    return "ERROR_NO_RECOVERY_PROGRAM";
                case 1083:
                    return "ERROR_SERVICE_NOT_IN_EXE";
                case 1084:
                    return "ERROR_NOT_SAFEBOOT_SERVICE";
                case 1100:
                    return "ERROR_END_OF_MEDIA";
                case 1101:
                    return "ERROR_FILEMARK_DETECTED";
                case 1102:
                    return "ERROR_BEGINNING_OF_MEDIA";
                case 1103:
                    return "ERROR_SETMARK_DETECTED";
                case 1104:
                    return "ERROR_NO_DATA_DETECTED";
                case 1105:
                    return "ERROR_PARTITION_FAILURE";
                case 1106:
                    return "ERROR_INVALID_BLOCK_LENGTH";
                case 1107:
                    return "ERROR_DEVICE_NOT_PARTITIONED";
                case 1108:
                    return "ERROR_UNABLE_TO_LOCK_MEDIA";
                case 1109:
                    return "ERROR_UNABLE_TO_UNLOAD_MEDIA";
                case 1110:
                    return "ERROR_MEDIA_CHANGED";
                case 1111:
                    return "ERROR_BUS_RESET";
                case 1112:
                    return "ERROR_NO_MEDIA_IN_DRIVE";
                case 1113:
                    return "ERROR_NO_UNICODE_TRANSLATION";
                case 1114:
                    return "ERROR_DLL_INIT_FAILED";
                case 1115:
                    return "ERROR_SHUTDOWN_IN_PROGRESS";
                case 1116:
                    return "ERROR_NO_SHUTDOWN_IN_PROGRESS";
                case 1117:
                    return "ERROR_IO_DEVICE";
                case 1118:
                    return "ERROR_SERIAL_NO_DEVICE";
                case 1119:
                    return "ERROR_IRQ_BUSY";
                case 1120:
                    return "ERROR_MORE_WRITES";
                case 1121:
                    return "ERROR_COUNTER_TIMEOUT";
                case 1122:
                    return "ERROR_FLOPPY_ID_MARK_NOT_FOUND";
                case 1123:
                    return "ERROR_FLOPPY_WRONG_CYLINDER";
                case 1124:
                    return "ERROR_FLOPPY_UNKNOWN_ERROR";
                case 1125:
                    return "ERROR_FLOPPY_BAD_REGISTERS";
                case 1126:
                    return "ERROR_DISK_RECALIBRATE_FAILED";
                case 1127:
                    return "ERROR_DISK_OPERATION_FAILED";
                case 1128:
                    return "ERROR_DISK_RESET_FAILED";
                case 1129:
                    return "ERROR_EOM_OVERFLOW";
                case 1130:
                    return "ERROR_NOT_ENOUGH_SERVER_MEMORY";
                case 1131:
                    return "ERROR_POSSIBLE_DEADLOCK";
                case 1132:
                    return "ERROR_MAPPED_ALIGNMENT";
                case 1140:
                    return "ERROR_SET_POWER_STATE_VETOED";
                case 1141:
                    return "ERROR_SET_POWER_STATE_FAILED";
                case 1142:
                    return "ERROR_TOO_MANY_LINKS";
                case 1150:
                    return "ERROR_OLD_WIN_VERSION";
                case 1151:
                    return "ERROR_APP_WRONG_OS";
                case 1152:
                    return "ERROR_SINGLE_INSTANCE_APP";
                case 1153:
                    return "ERROR_RMODE_APP";
                case 1154:
                    return "ERROR_INVALID_DLL";
                case 1155:
                    return "ERROR_NO_ASSOCIATION";
                case 1156:
                    return "ERROR_DDE_FAIL";
                case 1157:
                    return "ERROR_DLL_NOT_FOUND";
                case 1158:
                    return "ERROR_NO_MORE_USER_HANDLES";
                case 1159:
                    return "ERROR_MESSAGE_SYNC_ONLY";
                case 1160:
                    return "ERROR_SOURCE_ELEMENT_EMPTY";
                case 1161:
                    return "ERROR_DESTINATION_ELEMENT_FULL";
                case 1162:
                    return "ERROR_ILLEGAL_ELEMENT_ADDRESS";
                case 1163:
                    return "ERROR_MAGAZINE_NOT_PRESENT";
                case 1164:
                    return "ERROR_DEVICE_REINITIALIZATION_NEEDED";
                case 1165:
                    return "ERROR_DEVICE_REQUIRES_CLEANING";
                case 1166:
                    return "ERROR_DEVICE_DOOR_OPEN";
                case 1167:
                    return "ERROR_DEVICE_NOT_CONNECTED";
                case 1168:
                    return "ERROR_NOT_FOUND";
                case 1169:
                    return "ERROR_NO_MATCH";
                case 1170:
                    return "ERROR_SET_NOT_FOUND";
                case 1171:
                    return "ERROR_POINT_NOT_FOUND";
                case 1172:
                    return "ERROR_NO_TRACKING_SERVICE";
                case 1173:
                    return "ERROR_NO_VOLUME_ID";
                case 1175:
                    return "ERROR_UNABLE_TO_REMOVE_REPLACED";
                case 1176:
                    return "ERROR_UNABLE_TO_MOVE_REPLACEMENT";
                case 1177:
                    return "ERROR_UNABLE_TO_MOVE_REPLACEMENT_2";
                case 1178:
                    return "ERROR_JOURNAL_DELETE_IN_PROGRESS";
                case 1179:
                    return "ERROR_JOURNAL_NOT_ACTIVE";
                case 1180:
                    return "ERROR_POTENTIAL_FILE_FOUND";
                case 1181:
                    return "ERROR_JOURNAL_ENTRY_DELETED";
                case 1200:
                    return "ERROR_BAD_DEVICE";
                case 1201:
                    return "ERROR_CONNECTION_UNAVAIL";
                case 1202:
                    return "ERROR_DEVICE_ALREADY_REMEMBERED";
                case 1203:
                    return "ERROR_NO_NET_OR_BAD_PATH";
                case 1204:
                    return "ERROR_BAD_PROVIDER";
                case 1205:
                    return "ERROR_CANNOT_OPEN_PROFILE";
                case 1206:
                    return "ERROR_BAD_PROFILE";
                case 1207:
                    return "ERROR_NOT_CONTAINER";
                case 1208:
                    return "ERROR_EXTENDED_ERROR";
                case 1209:
                    return "ERROR_INVALID_GROUPNAME";
                case 1210:
                    return "ERROR_INVALID_COMPUTERNAME";
                case 1211:
                    return "ERROR_INVALID_EVENTNAME";
                case 1212:
                    return "ERROR_INVALID_DOMAINNAME";
                case 1213:
                    return "ERROR_INVALID_SERVICENAME";
                case 1214:
                    return "ERROR_INVALID_NETNAME";
                case 1215:
                    return "ERROR_INVALID_SHARENAME";
                case 1216:
                    return "ERROR_INVALID_PASSWORDNAME";
                case 1217:
                    return "ERROR_INVALID_MESSAGENAME";
                case 1218:
                    return "ERROR_INVALID_MESSAGEDEST";
                case 1219:
                    return "ERROR_SESSION_CREDENTIAL_CONFLICT";
                case 1220:
                    return "ERROR_REMOTE_SESSION_LIMIT_EXCEEDED";
                case 1221:
                    return "ERROR_DUP_DOMAINNAME";
                case 1222:
                    return "ERROR_NO_NETWORK";
                case 1223:
                    return "ERROR_CANCELLED";
                case 1224:
                    return "ERROR_USER_MAPPED_FILE";
                case 1225:
                    return "ERROR_CONNECTION_REFUSED";
                case 1226:
                    return "ERROR_GRACEFUL_DISCONNECT";
                case 1227:
                    return "ERROR_ADDRESS_ALREADY_ASSOCIATED";
                case 1228:
                    return "ERROR_ADDRESS_NOT_ASSOCIATED";
                case 1229:
                    return "ERROR_CONNECTION_INVALID";
                case 1230:
                    return "ERROR_CONNECTION_ACTIVE";
                case 1231:
                    return "ERROR_NETWORK_UNREACHABLE";
                case 1232:
                    return "ERROR_HOST_UNREACHABLE";
                case 1233:
                    return "ERROR_PROTOCOL_UNREACHABLE";
                case 1234:
                    return "ERROR_PORT_UNREACHABLE";
                case 1235:
                    return "ERROR_REQUEST_ABORTED";
                case 1236:
                    return "ERROR_CONNECTION_ABORTED";
                case 1237:
                    return "ERROR_RETRY";
                case 1238:
                    return "ERROR_CONNECTION_COUNT_LIMIT";
                case 1239:
                    return "ERROR_LOGIN_TIME_RESTRICTION";
                case 1240:
                    return "ERROR_LOGIN_WKSTA_RESTRICTION";
                case 1241:
                    return "ERROR_INCORRECT_ADDRESS";
                case 1242:
                    return "ERROR_ALREADY_REGISTERED";
                case 1243:
                    return "ERROR_SERVICE_NOT_FOUND";
                case 1244:
                    return "ERROR_NOT_AUTHENTICATED";
                case 1245:
                    return "ERROR_NOT_LOGGED_ON";
                case 1246:
                    return "ERROR_CONTINUE";
                case 1247:
                    return "ERROR_ALREADY_INITIALIZED";
                case 1248:
                    return "ERROR_NO_MORE_DEVICES";
                case 1249:
                    return "ERROR_NO_SUCH_SITE";
                case 1250:
                    return "ERROR_DOMAIN_CONTROLLER_EXISTS";
                case 1251:
                    return "ERROR_ONLY_IF_CONNECTED";
                case 1252:
                    return "ERROR_OVERRIDE_NOCHANGES";
                case 1253:
                    return "ERROR_BAD_USER_PROFILE";
                case 1254:
                    return "ERROR_NOT_SUPPORTED_ON_SBS";
                case 1255:
                    return "ERROR_SERVER_SHUTDOWN_IN_PROGRESS";
                case 1256:
                    return "ERROR_HOST_DOWN";
                case 1257:
                    return "ERROR_NON_ACCOUNT_SID";
                case 1258:
                    return "ERROR_NON_DOMAIN_SID";
                case 1259:
                    return "ERROR_APPHELP_BLOCK";
                case 1260:
                    return "ERROR_ACCESS_DISABLED_BY_POLICY";
                case 1261:
                    return "ERROR_REG_NAT_CONSUMPTION";
                case 1262:
                    return "ERROR_CSCSHARE_OFFLINE";
                case 1263:
                    return "ERROR_PKINIT_FAILURE";
                case 1264:
                    return "ERROR_SMARTCARD_SUBSYSTEM_FAILURE";
                case 1265:
                    return "ERROR_DOWNGRADE_DETECTED";
                case 1271:
                    return "ERROR_MACHINE_LOCKED";
                case 1273:
                    return "ERROR_CALLBACK_SUPPLIED_INVALID_DATA";
                case 1274:
                    return "ERROR_SYNC_FOREGROUND_REFRESH_REQUIRED";
                case 1275:
                    return "ERROR_DRIVER_BLOCKED";
                case 1276:
                    return "ERROR_INVALID_IMPORT_OF_NON_DLL";
                case 1277:
                    return "ERROR_ACCESS_DISABLED_WEBBLADE";
                case 1278:
                    return "ERROR_ACCESS_DISABLED_WEBBLADE_TAMPER";
                case 1279:
                    return "ERROR_RECOVERY_FAILURE";
                case 1280:
                    return "ERROR_ALREADY_FIBER";
                case 1281:
                    return "ERROR_ALREADY_THREAD";
                case 1282:
                    return "ERROR_STACK_BUFFER_OVERRUN";
                case 1283:
                    return "ERROR_PARAMETER_QUOTA_EXCEEDED";
                case 1284:
                    return "ERROR_DEBUGGER_INACTIVE";
                case 1285:
                    return "ERROR_DELAY_LOAD_FAILED";
                case 1286:
                    return "ERROR_VDM_DISALLOWED";
                case 1287:
                    return "ERROR_UNIDENTIFIED_ERROR";
                case 1300:
                    return "ERROR_NOT_ALL_ASSIGNED";
                case 1301:
                    return "ERROR_SOME_NOT_MAPPED";
                case 1302:
                    return "ERROR_NO_QUOTAS_FOR_ACCOUNT";
                case 1303:
                    return "ERROR_LOCAL_USER_SESSION_KEY";
                case 1304:
                    return "ERROR_NULL_LM_PASSWORD";
                case 1305:
                    return "ERROR_UNKNOWN_REVISION";
                case 1306:
                    return "ERROR_REVISION_MISMATCH";
                case 1307:
                    return "ERROR_INVALID_OWNER";
                case 1308:
                    return "ERROR_INVALID_PRIMARY_GROUP";
                case 1309:
                    return "ERROR_NO_IMPERSONATION_TOKEN";
                case 1310:
                    return "ERROR_CANT_DISABLE_MANDATORY";
                case 1311:
                    return "ERROR_NO_LOGON_SERVERS";
                case 1312:
                    return "ERROR_NO_SUCH_LOGON_SESSION";
                case 1313:
                    return "ERROR_NO_SUCH_PRIVILEGE";
                case 1314:
                    return "ERROR_PRIVILEGE_NOT_HELD";
                case 1315:
                    return "ERROR_INVALID_ACCOUNT_NAME";
                case 1316:
                    return "ERROR_USER_EXISTS";
                case 1317:
                    return "ERROR_NO_SUCH_USER";
                case 1318:
                    return "ERROR_GROUP_EXISTS";
                case 1319:
                    return "ERROR_NO_SUCH_GROUP";
                case 1320:
                    return "ERROR_MEMBER_IN_GROUP";
                case 1321:
                    return "ERROR_MEMBER_NOT_IN_GROUP";
                case 1322:
                    return "ERROR_LAST_ADMIN";
                case 1323:
                    return "ERROR_WRONG_PASSWORD";
                case 1324:
                    return "ERROR_ILL_FORMED_PASSWORD";
                case 1325:
                    return "ERROR_PASSWORD_RESTRICTION";
                case 1326:
                    return "ERROR_LOGON_FAILURE";
                case 1327:
                    return "ERROR_ACCOUNT_RESTRICTION";
                case 1328:
                    return "ERROR_INVALID_LOGON_HOURS";
                case 1329:
                    return "ERROR_INVALID_WORKSTATION";
                case 1330:
                    return "ERROR_PASSWORD_EXPIRED";
                case 1331:
                    return "ERROR_ACCOUNT_DISABLED";
                case 1332:
                    return "ERROR_NONE_MAPPED";
                case 1333:
                    return "ERROR_TOO_MANY_LUIDS_REQUESTED";
                case 1334:
                    return "ERROR_LUIDS_EXHAUSTED";
                case 1335:
                    return "ERROR_INVALID_SUB_AUTHORITY";
                case 1336:
                    return "ERROR_INVALID_ACL";
                case 1337:
                    return "ERROR_INVALID_SID";
                case 1338:
                    return "ERROR_INVALID_SECURITY_DESCR";
                case 1340:
                    return "ERROR_BAD_INHERITANCE_ACL";
                case 1341:
                    return "ERROR_SERVER_DISABLED";
                case 1342:
                    return "ERROR_SERVER_NOT_DISABLED";
                case 1343:
                    return "ERROR_INVALID_ID_AUTHORITY";
                case 1344:
                    return "ERROR_ALLOTTED_SPACE_EXCEEDED";
                case 1345:
                    return "ERROR_INVALID_GROUP_ATTRIBUTES";
                case 1346:
                    return "ERROR_BAD_IMPERSONATION_LEVEL";
                case 1347:
                    return "ERROR_CANT_OPEN_ANONYMOUS";
                case 1348:
                    return "ERROR_BAD_VALIDATION_CLASS";
                case 1349:
                    return "ERROR_BAD_TOKEN_TYPE";
                case 1350:
                    return "ERROR_NO_SECURITY_ON_OBJECT";
                case 1351:
                    return "ERROR_CANT_ACCESS_DOMAIN_INFO";
                case 1352:
                    return "ERROR_INVALID_SERVER_STATE";
                case 1353:
                    return "ERROR_INVALID_DOMAIN_STATE";
                case 1354:
                    return "ERROR_INVALID_DOMAIN_ROLE";
                case 1355:
                    return "ERROR_NO_SUCH_DOMAIN";
                case 1356:
                    return "ERROR_DOMAIN_EXISTS";
                case 1357:
                    return "ERROR_DOMAIN_LIMIT_EXCEEDED";
                case 1358:
                    return "ERROR_INTERNAL_DB_CORRUPTION";
                case 1359:
                    return "ERROR_INTERNAL_ERROR";
                case 1360:
                    return "ERROR_GENERIC_NOT_MAPPED";
                case 1361:
                    return "ERROR_BAD_DESCRIPTOR_FORMAT";
                case 1362:
                    return "ERROR_NOT_LOGON_PROCESS";
                case 1363:
                    return "ERROR_LOGON_SESSION_EXISTS";
                case 1364:
                    return "ERROR_NO_SUCH_PACKAGE";
                case 1365:
                    return "ERROR_BAD_LOGON_SESSION_STATE";
                case 1366:
                    return "ERROR_LOGON_SESSION_COLLISION";
                case 1367:
                    return "ERROR_INVALID_LOGON_TYPE";
                case 1368:
                    return "ERROR_CANNOT_IMPERSONATE";
                case 1369:
                    return "ERROR_RXACT_INVALID_STATE";
                case 1370:
                    return "ERROR_RXACT_COMMIT_FAILURE";
                case 1371:
                    return "ERROR_SPECIAL_ACCOUNT";
                case 1372:
                    return "ERROR_SPECIAL_GROUP";
                case 1373:
                    return "ERROR_SPECIAL_USER";
                case 1374:
                    return "ERROR_MEMBERS_PRIMARY_GROUP";
                case 1375:
                    return "ERROR_TOKEN_ALREADY_IN_USE";
                case 1376:
                    return "ERROR_NO_SUCH_ALIAS";
                case 1377:
                    return "ERROR_MEMBER_NOT_IN_ALIAS";
                case 1378:
                    return "ERROR_MEMBER_IN_ALIAS";
                case 1379:
                    return "ERROR_ALIAS_EXISTS";
                case 1380:
                    return "ERROR_LOGON_NOT_GRANTED";
                case 1381:
                    return "ERROR_TOO_MANY_SECRETS";
                case 1382:
                    return "ERROR_SECRET_TOO_LONG";
                case 1383:
                    return "ERROR_INTERNAL_DB_ERROR";
                case 1384:
                    return "ERROR_TOO_MANY_CONTEXT_IDS";
                case 1385:
                    return "ERROR_LOGON_TYPE_NOT_GRANTED";
                case 1386:
                    return "ERROR_NT_CROSS_ENCRYPTION_REQUIRED";
                case 1387:
                    return "ERROR_NO_SUCH_MEMBER";
                case 1388:
                    return "ERROR_INVALID_MEMBER";
                case 1389:
                    return "ERROR_TOO_MANY_SIDS";
                case 1390:
                    return "ERROR_LM_CROSS_ENCRYPTION_REQUIRED";
                case 1391:
                    return "ERROR_NO_INHERITANCE";
                case 1392:
                    return "ERROR_FILE_CORRUPT";
                case 1393:
                    return "ERROR_DISK_CORRUPT";
                case 1394:
                    return "ERROR_NO_USER_SESSION_KEY";
                case 1395:
                    return "ERROR_LICENSE_QUOTA_EXCEEDED";
                case 1396:
                    return "ERROR_WRONG_TARGET_NAME";
                case 1397:
                    return "ERROR_MUTUAL_AUTH_FAILED";
                case 1398:
                    return "ERROR_TIME_SKEW";
                case 1399:
                    return "ERROR_CURRENT_DOMAIN_NOT_ALLOWED";
                case 1400:
                    return "ERROR_INVALID_WINDOW_HANDLE";
                case 1401:
                    return "ERROR_INVALID_MENU_HANDLE";
                case 1402:
                    return "ERROR_INVALID_CURSOR_HANDLE";
                case 1403:
                    return "ERROR_INVALID_ACCEL_HANDLE";
                case 1404:
                    return "ERROR_INVALID_HOOK_HANDLE";
                case 1405:
                    return "ERROR_INVALID_DWP_HANDLE";
                case 1406:
                    return "ERROR_TLW_WITH_WSCHILD";
                case 1407:
                    return "ERROR_CANNOT_FIND_WND_CLASS";
                case 1408:
                    return "ERROR_WINDOW_OF_OTHER_THREAD";
                case 1409:
                    return "ERROR_HOTKEY_ALREADY_REGISTERED";
                case 1410:
                    return "ERROR_CLASS_ALREADY_EXISTS";
                case 1411:
                    return "ERROR_CLASS_DOES_NOT_EXIST";
                case 1412:
                    return "ERROR_CLASS_HAS_WINDOWS";
                case 1413:
                    return "ERROR_INVALID_INDEX";
                case 1414:
                    return "ERROR_INVALID_ICON_HANDLE";
                case 1415:
                    return "ERROR_PRIVATE_DIALOG_INDEX";
                case 1416:
                    return "ERROR_LISTBOX_ID_NOT_FOUND";
                case 1417:
                    return "ERROR_NO_WILDCARD_CHARACTERS";
                case 1418:
                    return "ERROR_CLIPBOARD_NOT_OPEN";
                case 1419:
                    return "ERROR_HOTKEY_NOT_REGISTERED";
                case 1420:
                    return "ERROR_WINDOW_NOT_DIALOG";
                case 1421:
                    return "ERROR_CONTROL_ID_NOT_FOUND";
                case 1422:
                    return "ERROR_INVALID_COMBOBOX_MESSAGE";
                case 1423:
                    return "ERROR_WINDOW_NOT_COMBOBOX";
                case 1424:
                    return "ERROR_INVALID_EDIT_HEIGHT";
                case 1425:
                    return "ERROR_DC_NOT_FOUND";
                case 1426:
                    return "ERROR_INVALID_HOOK_FILTER";
                case 1427:
                    return "ERROR_INVALID_FILTER_PROC";
                case 1428:
                    return "ERROR_HOOK_NEEDS_HMOD";
                case 1429:
                    return "ERROR_GLOBAL_ONLY_HOOK";
                case 1430:
                    return "ERROR_JOURNAL_HOOK_SET";
                case 1431:
                    return "ERROR_HOOK_NOT_INSTALLED";
                case 1432:
                    return "ERROR_INVALID_LB_MESSAGE";
                case 1433:
                    return "ERROR_SETCOUNT_ON_BAD_LB";
                case 1434:
                    return "ERROR_LB_WITHOUT_TABSTOPS";
                case 1435:
                    return "ERROR_DESTROY_OBJECT_OF_OTHER_THREAD";
                case 1436:
                    return "ERROR_CHILD_WINDOW_MENU";
                case 1437:
                    return "ERROR_NO_SYSTEM_MENU";
                case 1438:
                    return "ERROR_INVALID_MSGBOX_STYLE";
                case 1439:
                    return "ERROR_INVALID_SPI_VALUE";
                case 1440:
                    return "ERROR_SCREEN_ALREADY_LOCKED";
                case 1441:
                    return "ERROR_HWNDS_HAVE_DIFF_PARENT";
                case 1442:
                    return "ERROR_NOT_CHILD_WINDOW";
                case 1443:
                    return "ERROR_INVALID_GW_COMMAND";
                case 1444:
                    return "ERROR_INVALID_THREAD_ID";
                case 1445:
                    return "ERROR_NON_MDICHILD_WINDOW";
                case 1446:
                    return "ERROR_POPUP_ALREADY_ACTIVE";
                case 1447:
                    return "ERROR_NO_SCROLLBARS";
                case 1448:
                    return "ERROR_INVALID_SCROLLBAR_RANGE";
                case 1449:
                    return "ERROR_INVALID_SHOWWIN_COMMAND";
                case 1450:
                    return "ERROR_NO_SYSTEM_RESOURCES";
                case 1451:
                    return "ERROR_NONPAGED_SYSTEM_RESOURCES";
                case 1452:
                    return "ERROR_PAGED_SYSTEM_RESOURCES";
                case 1453:
                    return "ERROR_WORKING_SET_QUOTA";
                case 1454:
                    return "ERROR_PAGEFILE_QUOTA";
                case 1455:
                    return "ERROR_COMMITMENT_LIMIT";
                case 1456:
                    return "ERROR_MENU_ITEM_NOT_FOUND";
                case 1457:
                    return "ERROR_INVALID_KEYBOARD_HANDLE";
                case 1458:
                    return "ERROR_HOOK_TYPE_NOT_ALLOWED";
                case 1459:
                    return "ERROR_REQUIRES_INTERACTIVE_WINDOWSTATION";
                case 1460:
                    return "ERROR_TIMEOUT";
                case 1461:
                    return "ERROR_INVALID_MONITOR_HANDLE";
                case 1462:
                    return "ERROR_INCORRECT_SIZE";
                case 1500:
                    return "ERROR_EVENTLOG_FILE_CORRUPT";
                case 1501:
                    return "ERROR_EVENTLOG_CANT_START";
                case 1502:
                    return "ERROR_LOG_FILE_FULL";
                case 1503:
                    return "ERROR_EVENTLOG_FILE_CHANGED";
                case 1601:
                    return "ERROR_INSTALL_SERVICE_FAILURE";
                case 1602:
                    return "ERROR_INSTALL_USEREXIT";
                case 1603:
                    return "ERROR_INSTALL_FAILURE";
                case 1604:
                    return "ERROR_INSTALL_SUSPEND";
                case 1605:
                    return "ERROR_UNKNOWN_PRODUCT";
                case 1606:
                    return "ERROR_UNKNOWN_FEATURE";
                case 1607:
                    return "ERROR_UNKNOWN_COMPONENT";
                case 1608:
                    return "ERROR_UNKNOWN_PROPERTY";
                case 1609:
                    return "ERROR_INVALID_HANDLE_STATE";
                case 1610:
                    return "ERROR_BAD_CONFIGURATION";
                case 1611:
                    return "ERROR_INDEX_ABSENT";
                case 1612:
                    return "ERROR_INSTALL_SOURCE_ABSENT";
                case 1613:
                    return "ERROR_INSTALL_PACKAGE_VERSION";
                case 1614:
                    return "ERROR_PRODUCT_UNINSTALLED";
                case 1615:
                    return "ERROR_BAD_QUERY_SYNTAX";
                case 1616:
                    return "ERROR_INVALID_FIELD";
                case 1617:
                    return "ERROR_DEVICE_REMOVED";
                case 1618:
                    return "ERROR_INSTALL_ALREADY_RUNNING";
                case 1619:
                    return "ERROR_INSTALL_PACKAGE_OPEN_FAILED";
                case 1620:
                    return "ERROR_INSTALL_PACKAGE_INVALID";
                case 1621:
                    return "ERROR_INSTALL_UI_FAILURE";
                case 1622:
                    return "ERROR_INSTALL_LOG_FAILURE";
                case 1623:
                    return "ERROR_INSTALL_LANGUAGE_UNSUPPORTED";
                case 1624:
                    return "ERROR_INSTALL_TRANSFORM_FAILURE";
                case 1625:
                    return "ERROR_INSTALL_PACKAGE_REJECTED";
                case 1626:
                    return "ERROR_FUNCTION_NOT_CALLED";
                case 1627:
                    return "ERROR_FUNCTION_FAILED";
                case 1628:
                    return "ERROR_INVALID_TABLE";
                case 1629:
                    return "ERROR_DATATYPE_MISMATCH";
                case 1630:
                    return "ERROR_UNSUPPORTED_TYPE";
                case 1631:
                    return "ERROR_CREATE_FAILED";
                case 1632:
                    return "ERROR_INSTALL_TEMP_UNWRITABLE";
                case 1633:
                    return "ERROR_INSTALL_PLATFORM_UNSUPPORTED";
                case 1634:
                    return "ERROR_INSTALL_NOTUSED";
                case 1635:
                    return "ERROR_PATCH_PACKAGE_OPEN_FAILED";
                case 1636:
                    return "ERROR_PATCH_PACKAGE_INVALID";
                case 1637:
                    return "ERROR_PATCH_PACKAGE_UNSUPPORTED";
                case 1638:
                    return "ERROR_PRODUCT_VERSION";
                case 1639:
                    return "ERROR_INVALID_COMMAND_LINE";
                case 1640:
                    return "ERROR_INSTALL_REMOTE_DISALLOWED";
                case 1641:
                    return "ERROR_SUCCESS_REBOOT_INITIATED";
                case 1642:
                    return "ERROR_PATCH_TARGET_NOT_FOUND";
                case 1643:
                    return "ERROR_PATCH_PACKAGE_REJECTED";
                case 1644:
                    return "ERROR_INSTALL_TRANSFORM_REJECTED";
                case 1645:
                    return "ERROR_INSTALL_REMOTE_PROHIBITED";
                case 10004:
                    return "WSAEINTR";
                case 10009:
                    return "WSAEBADF";
                case 10013:
                    return "WSAEACCES";
                case 10014:
                    return "WSAEFAULT";
                case 10022:
                    return "WSAEINVAL";
                case 10024:
                    return "WSAEMFILE";
                case 10035:
                    return "WSAEWOULDBLOCK";
                case 10036:
                    return "WSAEINPROGRESS";
                case 10037:
                    return "WSAEALREADY";
                case 10038:
                    return "WSAENOTSOCK";
                case 10039:
                    return "WSAEDESTADDRREQ";
                case 10040:
                    return "WSAEMSGSIZE";
                case 10041:
                    return "WSAEPROTOTYPE";
                case 10042:
                    return "WSAENOPROTOOPT";
                case 10043:
                    return "WSAEPROTONOSUPPORT";
                case 10044:
                    return "WSAESOCKTNOSUPPORT";
                case 10045:
                    return "WSAEOPNOTSUPP";
                case 10046:
                    return "WSAEPFNOSUPPORT";
                case 10047:
                    return "WSAEAFNOSUPPORT";
                case 10048:
                    return "WSAEADDRINUSE";
                case 10049:
                    return "WSAEADDRNOTAVAIL";
                case 10050:
                    return "WSAENETDOWN";
                case 10051:
                    return "WSAENETUNREACH";
                case 10052:
                    return "WSAENETRESET";
                case 10053:
                    return "WSAECONNABORTED";
                case 10054:
                    return "WSAECONNRESET";
                case 10055:
                    return "WSAENOBUFS";
                case 10056:
                    return "WSAEISCONN";
                case 10057:
                    return "WSAENOTCONN";
                case 10058:
                    return "WSAESHUTDOWN";
                case 10059:
                    return "WSAETOOMANYREFS";
                case 10060:
                    return "WSAETIMEDOUT";
                case 10061:
                    return "WSAECONNREFUSED";
                case 10062:
                    return "WSAELOOP";
                case 10063:
                    return "WSAENAMETOOLONG";
                case 10064:
                    return "WSAEHOSTDOWN";
                case 10065:
                    return "WSAEHOSTUNREACH";
                case 10066:
                    return "WSAENOTEMPTY";
                case 10067:
                    return "WSAEPROCLIM";
                case 10068:
                    return "WSAEUSERS";
                case 10069:
                    return "WSAEDQUOT";
                case 10070:
                    return "WSAESTALE";
                case 10071:
                    return "WSAEREMOTE";
                case 10091:
                    return "WSASYSNOTREADY";
                case 10092:
                    return "WSAVERNOTSUPPORTED";
                case 10093:
                    return "WSANOTINITIALISED";
                case 10101:
                    return "WSAEDISCON";
                case 10102:
                    return "WSAENOMORE";
                case 10103:
                    return "WSAECANCELLED";
                case 10104:
                    return "WSAEINVALIDPROCTABLE";
                case 10105:
                    return "WSAEINVALIDPROVIDER";
                case 10106:
                    return "WSAEPROVIDERFAILEDINIT";
                case 10107:
                    return "WSASYSCALLFAILURE";
                case 10108:
                    return "WSASERVICE_NOT_FOUND";
                case 10109:
                    return "WSATYPE_NOT_FOUND";
                case 10110:
                    return "WSA_E_NO_MORE";
                case 10111:
                    return "WSA_E_CANCELLED";
                case 10112:
                    return "WSAEREFUSED";
                case 11001:
                    return "WSAHOST_NOT_FOUND";
                case 11002:
                    return "WSATRY_AGAIN";
                case 11003:
                    return "WSANO_RECOVERY";
                case 11004:
                    return "WSANO_DATA";
                case 11005:
                    return "WSA_QOS_RECEIVERS";
                case 11006:
                    return "WSA_QOS_SENDERS";
                case 11007:
                    return "WSA_QOS_NO_SENDERS";
                case 11008:
                    return "WSA_QOS_NO_RECEIVERS";
                case 11009:
                    return "WSA_QOS_REQUEST_CONFIRMED";
                case 11010:
                    return "WSA_QOS_ADMISSION_FAILURE";
                case 11011:
                    return "WSA_QOS_POLICY_FAILURE";
                case 11012:
                    return "WSA_QOS_BAD_STYLE";
                case 11013:
                    return "WSA_QOS_BAD_OBJECT";
                case 11014:
                    return "WSA_QOS_TRAFFIC_CTRL_ERROR";
                case 11015:
                    return "WSA_QOS_GENERIC_ERROR";
                case 11016:
                    return "WSA_QOS_ESERVICETYPE";
                case 11017:
                    return "WSA_QOS_EFLOWSPEC";
                case 11018:
                    return "WSA_QOS_EPROVSPECBUF";
                case 11019:
                    return "WSA_QOS_EFILTERSTYLE";
                case 11020:
                    return "WSA_QOS_EFILTERTYPE";
                case 11021:
                    return "WSA_QOS_EFILTERCOUNT";
                case 11022:
                    return "WSA_QOS_EOBJLENGTH";
                case 11023:
                    return "WSA_QOS_EFLOWCOUNT";
                case 11024:
                    return "WSA_QOS_EUNKOWNPSOBJ";
                case 11025:
                    return "WSA_QOS_EPOLICYOBJ";
                case 11026:
                    return "WSA_QOS_EFLOWDESC";
                case 11027:
                    return "WSA_QOS_EPSFLOWSPEC";
                case 11028:
                    return "WSA_QOS_EPSFILTERSPEC";
                case 11029:
                    return "WSA_QOS_ESDMODEOBJ";
                case 11030:
                    return "WSA_QOS_ESHAPERATEOBJ";
                case 11031:
                    return "WSA_QOS_RESERVED_PETYPE";
                case 50103:
                    return "SE_ERR_TOOL_FUNC_NOT_SUPPORT";
                case 50109:
                    return "SE_ERR_INSUFFICIENCY_IMAGE";
                case 50301:
                    return "SE_ERR_SCSI_INVALID_PARAMS";
                case 50302:
                    return "SE_ERR_SCSI_INTERNAL_ERROR";
                case 50303:
                    return "SE_ERR_SCSI_DEVICE_NOT_OPENED";
                case 50304:
                    return "SE_ERR_SCSI_OPEN_DEVICE_FAIL";
                case 50305:
                    return "SE_ERR_SCSI_SEND_COMMAND_FAIL";
                case 50306:
                    return "SE_ERR_SCSI_MISMATCH_RESPONSE";
                case 50307:
                    return "SE_ERR_SCSI_NO_SD_CARD";
                case 50308:
                    return "SE_ERR_SD_NO_ENOUGH_SPACE";
                case 50309:
                    return "SE_ERR_ACCESS_DEVICE_DENIED";
                case 50701:
                    return "SE_ERR_SUT_INTERNAL_ERROR";
                case 50702:
                    return "SE_ERR_SUT_PHONE_KEY_ACCESS_FAIL";
                case 50703:
                    return "SE_ERR_SUT_DEVICE_MODE_NOT_SUPPORT";
                case 50704:
                    return "SE_ERR_SUT_DEVICE_INSTANCE_FAIL";
                case 50705:
                    return "SE_ERR_SUT_BATT_LEVEL_TOO_LOW";
                case 50706:
                    return "SE_ERR_SUT_CHECK_SW_IMAGE_FAIL";
                case 50707:
                    return "SE_ERR_SUT_PARSE_INFO_FAIL";
                case 50708:
                    return "SE_ERR_SUT_COMMAND_FAIL";
                case 50709:
                    return "SE_ERR_SUT_INVALID_PARAMS";
                case 50710:
                    return "SE_ERR_SUT_OBSOLETE_IMAGE";
                case 50711:
                    return "SE_ERR_SUT_ERROR_SIG_IMAGE";
                case 50712:
                    return "SE_ERR_SUT_NOT_ALLOW_DOWNGRADE";
                case 50713:
                    return "SE_ERR_SUT_FLASH_CAPACITY_NOT_MATCH";
                case 50714:
                    return "SE_ERR_SUT_CREATE_CUST_IMAGE_FAIL";
                case 50715:
                    return "SE_ERR_SUT_DETECT_EMMC_DISK_FAIL";
                case 50716:
                    return "SE_ERR_SUT_SWITCH_DEVICE_MODE_FAIL";
                case 50717:
                    return "SE_ERR_SUT_INVALID_IMAGE_PATH";
                case 50718:
                    return "SE_ERR_SUT_INVALID_IMAGE_FORMAT";
                case 50719:
                    return "SE_ERR_SUT_ACCESS_IMAGE_PATH";
                case 50721:
                    return "SE_ERR_SUT_HANDLE_RSD_LITE";
                case 50723:
                    return "SE_ERR_SUT_SECURITY_DENY";
                case 50725:
                    return "SE_ERR_SUT_UNKNOWN_OPTION";
                case 50726:
                    return "SE_ERR_SUT_AUTHENTICATION";
                case 51003:
                    return "SE_ERR_SUT_BCT_OR_PT_MISSED";
                case 51601:
                    return "SW_ERR_SIM_LOCK_UNKNWON_FUNC_TYPE";
                case 51602:
                    return "SW_ERR_SIM_LOCK_GET_STATUS_FAIL";
                case 51603:
                    return "SW_ERR_SIM_LOCK_DO_LOCK_FAIL";
                case 51604:
                    return "SW_ERR_SIM_LOCK_DO_UNLOCK_FAIL";
                default:
                    return "0x" + value.ToString("x4");
            }
        }

        public static string LocaleStringOf(long value)
        {
            switch (value)
            {
                case 0:
                    return string.Empty;
                case 1223:
                    return Locale.Instance.LoadText("USERMSG_CANCEL_ACTION");
                case 50103:
                    return Locale.Instance.LoadText("USERMSG_TOOL_FUNC_NOT_SUPPORT");
                case 50109:
                case 51003:
                    return Locale.Instance.LoadText("USERMSG_INSUFFICIENCY_IMAGE");
                case 50705:
                    return Locale.Instance.LoadText("USERMSG_BATT_LEVEL_LOW");
                case 50706:
                    return Locale.Instance.LoadText("USERMSG_INVALID_IMAGE");
                case 50710:
                    return Locale.Instance.LoadText("USERMSG_OBSOLETE_IMAGE");
                case 50711:
                case 50718:
                    return Locale.Instance.LoadText("USERMSG_ERROR_SIG_IMAGE");
                case 50712:
                    return Locale.Instance.LoadText("USERMSG_NOT_ALLOW_DOWNGRADE");
                case 50717:
                    return Locale.Instance.LoadText("USERMSG_INVALID_IMAGE_PATH");
                case 50719:
                    return Locale.Instance.LoadText("USERMSG_ACCESS_IMAGE_PATH");
                case 50723:
                    return Locale.Instance.LoadText("USERMSG_SECURITY_DENY");
                case 51201:
                    return Locale.Instance.LoadText("USERMSG_REQUIRE_DOT_NET_FRAMEWORK40");
                case 51301:
                    return Locale.Instance.LoadText("USERMSG_ROCKEY_READ_FAIL");
                case 51303:
                    return Locale.Instance.LoadText("USERMSG_ROCKEY_NO_PERMISSION");
                default:
                    return string.Empty;
            }
        }
    }
}
