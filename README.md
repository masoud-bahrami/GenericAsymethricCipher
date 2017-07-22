# GenericAsymmetricCipher
The GenericAsymmetricCipher, is a generic class, which you can use for Encription/Decription, using Dot Net Asymmetric Algorithms.
It suport 

  /// System.Security.Cryptography.SymmetricAlgorithm
  
  /// System.Security.Cryptography.Aes
  
  /// System.Security.Cryptography.DES
  
  /// System.Security.Cryptography.RC2
  
  /// System.Security.Cryptography.Rijndael
  
  /// System.Security.Cryptography.TripleDES
  
  Algorithms.

CipherUtility.Encrypt<Rijndael>("your clear text");

CipherUtility.Encrypt<Aes>("your clear text");

CipherUtility.Encrypt<DES>("your clear text");

CipherUtility.Encrypt<RC2>("your clear text");

CipherUtility.Encrypt<TripleDES>("your clear text");

Then for decript the encripted text:

CipherUtility.Decrypt<Rijndael>("your encripted text");

CipherUtility.Decrypt<Aes>("your encripted text");

CipherUtility.Decrypt<DES>("your encripted text");

CipherUtility.Decrypt<RC2>("your encripted text");

CipherUtility.Decrypt<TripleDES>("your encripted text");
