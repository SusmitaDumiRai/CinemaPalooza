using System.Text;

namespace EmployeeApp
{
    public class frmEncryptionController
    {
        //16 bit salt key
        private string key = "CINEMAPALOOZA123";
      
        //XOR Cipher 
        //To decrypt, apply the code again to the encrypted string. 
        public string encryptOrDecrypt(string password)
        {
            var result = new StringBuilder();

            for (int c = 0; c < password.Length; c++)
            {
                // take next character from string
                char character = password[c];

                // cast to a uint
                uint charCode = (uint)character;

                // figure out which character to take from the key
                int keyPosition = c % key.Length; // use modulo to "wrap round"

                // take the key character
                char keyChar = key[keyPosition];

                // cast it to a uint also
                uint keyCode = (uint)keyChar;

                // perform XOR on the two character codes
                uint combinedCode = charCode ^ keyCode;

                // cast back to a char
                char combinedChar = (char)combinedCode;

                // add to the result
                result.Append(combinedChar);
            }

            //Return the encrypted/decrypted string
            return result.ToString();
        }
    }
}
