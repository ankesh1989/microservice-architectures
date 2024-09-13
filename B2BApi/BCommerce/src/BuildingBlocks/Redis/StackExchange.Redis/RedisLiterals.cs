﻿namespace StackExchange.Redis
{
    internal static class CommonReplies
    {
        public static readonly CommandBytes
            ASK = "ASK ",
            authFail_trimmed = CommandBytes.TrimToFit("ERR operation not permitted"),
            backgroundSavingStarted_trimmed = CommandBytes.TrimToFit("Background saving started"),
            backgroundSavingAOFStarted_trimmed = CommandBytes.TrimToFit("Background append only file rewriting started"),
            databases = "databases",
            loading = "LOADING ",
            MOVED = "MOVED ",
            NOAUTH = "NOAUTH ",
            NOSCRIPT = "NOSCRIPT ",
            no = "no",
            OK = "OK",
            one = "1",
            PONG = "PONG",
            QUEUED = "QUEUED",
            READONLY = "READONLY ",
            replica_read_only = "replica-read-only",
            slave_read_only = "slave-read-only",
            timeout = "timeout",
            wildcard = "*",
            WRONGPASS = "WRONGPASS",
            yes = "yes",
            zero = "0",

            // streams
            length = "length",
            radixTreeKeys = "radix-tree-keys",
            radixTreeNodes = "radix-tree-nodes",
            groups = "groups",
            lastGeneratedId = "last-generated-id",
            firstEntry = "first-entry",
            lastEntry = "last-entry",

            // HELLO
            version = "version",
            proto = "proto",
            role = "role",
            mode = "mode",
            id = "id";
    }
    internal static class RedisLiterals
    {
        // unlike primary commands, these do not get altered by the command-map; we may as
        // well compute the bytes once and share them
        public static readonly RedisValue
            ACLCAT = "ACLCAT",
            ADDR = "ADDR",
            AFTER = "AFTER",
            AGGREGATE = "AGGREGATE",
            ALPHA = "ALPHA",
            AND = "AND",
            ANY = "ANY",
            ASC = "ASC",
            AUTH = "AUTH",
            BEFORE = "BEFORE",
            BIT = "BIT",
            BY = "BY",
            BYLEX = "BYLEX",
            BYSCORE = "BYSCORE",
            BYTE = "BYTE",
            CH = "CH",
            CHANNELS = "CHANNELS",
            COPY = "COPY",
            COUNT = "COUNT",
            DB = "DB",
            @default = "default",
            DESC = "DESC",
            DOCTOR = "DOCTOR",
            ENCODING = "ENCODING",
            EX = "EX",
            EXAT = "EXAT",
            EXISTS = "EXISTS",
            FILTERBY = "FILTERBY",
            FLUSH = "FLUSH",
            FREQ = "FREQ",
            GET = "GET",
            GETKEYS = "GETKEYS",
            GETNAME = "GETNAME",
            GT = "GT",
            HISTORY = "HISTORY",
            ID = "ID",
            IDX = "IDX",
            IDLETIME = "IDLETIME",
            KEEPTTL = "KEEPTTL",
            KILL = "KILL",
            LATEST = "LATEST",
            LEFT = "LEFT",
            LEN = "LEN",
            lib_name = "lib-name",
            lib_ver = "lib-ver",
            LIMIT = "LIMIT",
            LIST = "LIST",
            LOAD = "LOAD",
            LT = "LT",
            MATCH = "MATCH",
            MALLOC_STATS = "MALLOC-STATS",
            MAX = "MAX",
            MAXLEN = "MAXLEN",
            MIN = "MIN",
            MINMATCHLEN = "MINMATCHLEN",
            MODULE = "MODULE",
            NODES = "NODES",
            NOSAVE = "NOSAVE",
            NOT = "NOT",
            NUMPAT = "NUMPAT",
            NUMSUB = "NUMSUB",
            NX = "NX",
            OBJECT = "OBJECT",
            OR = "OR",
            PATTERN = "PATTERN",
            PAUSE = "PAUSE",
            PERSIST = "PERSIST",
            PING = "PING",
            PURGE = "PURGE",
            PX = "PX",
            PXAT = "PXAT",
            RANK = "RANK",
            REFCOUNT = "REFCOUNT",
            REPLACE = "REPLACE",
            RESET = "RESET",
            RESETSTAT = "RESETSTAT",
            REV = "REV",
            REWRITE = "REWRITE",
            RIGHT = "RIGHT",
            SAVE = "SAVE",
            SEGFAULT = "SEGFAULT",
            SET = "SET",
            SETINFO = "SETINFO",
            SETNAME = "SETNAME",
            SKIPME = "SKIPME",
            STATS = "STATS",
            STORE = "STORE",
            TYPE = "TYPE",
            WEIGHTS = "WEIGHTS",
            WITHMATCHLEN = "WITHMATCHLEN",
            WITHSCORES = "WITHSCORES",
            WITHVALUES = "WITHVALUES",
            XOR = "XOR",
            XX = "XX",

            // Sentinel Literals
            MASTERS = "MASTERS",
            MASTER = "MASTER",
            REPLICAS = "REPLICAS",
            SLAVES = "SLAVES",
            GETMASTERADDRBYNAME = "GET-MASTER-ADDR-BY-NAME",
            //            RESET = "RESET",
            FAILOVER = "FAILOVER",
            SENTINELS = "SENTINELS",

            // Sentinel Literals as of 2.8.4
            MONITOR = "MONITOR",
            REMOVE = "REMOVE",
            //            SET = "SET",

            // replication states
            connect = "connect",
            connected = "connected",
            connecting = "connecting",
            handshake = "handshake",
            none = "none",
            sync = "sync",

            MinusSymbol = "-",
            PlusSymbol = "+",
            Wildcard = "*",

            // Geo Radius/Search Literals
            BYBOX = "BYBOX",
            BYRADIUS = "BYRADIUS",
            FROMMEMBER = "FROMMEMBER",
            FROMLONLAT = "FROMLONLAT",
            STOREDIST = "STOREDIST",
            WITHCOORD = "WITHCOORD",
            WITHDIST = "WITHDIST",
            WITHHASH = "WITHHASH",

            // geo units
            ft = "ft",
            km = "km",
            m = "m",
            mi = "mi",

            // misc (config, etc)
            databases = "databases",
            master = "master",
            no = "no",
            normal = "normal",
            pubsub = "pubsub",
            replica = "replica",
            replica_read_only = "replica-read-only",
            replication = "replication",
            sentinel = "sentinel",
            server = "server",
            slave = "slave",
            slave_read_only = "slave-read-only",
            timeout = "timeout",
            yes = "yes";

        internal static RedisValue Get(Bitwise operation) => operation switch
        {
            Bitwise.And => AND,
            Bitwise.Or => OR,
            Bitwise.Xor => XOR,
            Bitwise.Not => NOT,
            _ => throw new ArgumentOutOfRangeException(nameof(operation)),
        };
    }
}
