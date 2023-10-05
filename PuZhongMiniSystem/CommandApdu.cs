using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuZhongMiniSystem {
    internal class CommandApdu {
        public byte CLA;
        public byte INS;
        public byte P1;
        public byte P2;
        public byte Le;

        /*
        public CommandApdu(IsoCase isoCase, SmartCardProtocol protocol) {
            this.isoCase = isoCase;
            this.protocol = protocol;
        }
        */

        public CommandApdu() {
        }

        /*
        public byte[] GetBytes() {
            byte[] bytes = new byte[7];
            bytes[0] = (byte)isoCase;
            bytes[1] = protocol;
            bytes[2] = cla;
            bytes[3] = ins;
            bytes[4] = p1;
            bytes[5] = p2;
            bytes[6] = le;
            return bytes;
        }
        */

        public byte[] GetBytes() {
            byte[] bytes = new byte[5];
            bytes[0] = CLA;
            bytes[1] = INS;
            bytes[2] = P1;
            bytes[3] = P2;
            bytes[4] = Le;
            return bytes;
        }

        /*
        public static CommandApdu FromBytes(byte[] bytes) {
            if (bytes.Length != 7) {
                throw new ArgumentException("Invalid APDU length");
            }
            CommandApdu apdu = new CommandApdu();
            apdu.isoCase = (IsoCase)bytes[0];
            apdu.protocol = (SmartCardProtocol)bytes[1];
            apdu.cla = bytes[2];
            apdu.ins = bytes[3];
            apdu.p1 = bytes[4];
            apdu.p2 = bytes[5];
            apdu.le = bytes[6];
            return apdu;
        }
        */
        public static CommandApdu FromBytes(byte[] bytes) {
            if (bytes.Length != 5) {
                throw new ArgumentException("Invalid APDU length");
            }
            CommandApdu apdu = new CommandApdu();
            apdu.CLA = bytes[0];
            apdu.INS = bytes[1];
            apdu.P1 = bytes[2];
            apdu.P2 = bytes[3];
            apdu.Le = bytes[4];
            return apdu;
        }
    }
}
