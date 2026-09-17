
using System;
using System.IO;
using UnityEngine;

namespace TiltanMobileSummer2026.Generic
{
    public static class AudioSave
    { 
        /// <summary>
        /// Saves an AudioClip to a .wav file at the specified path.
        /// If relativePath is true, it appends the filename to Application.persistentDataPath.
        /// </summary>
        public static bool SaveToWav(AudioClip clip, string filePath, bool relativeToPersistentDataPath = true)
        {
            if (clip == null)
            {
                Debug.LogError("AudioSaveService: Provided AudioClip is null.");
                return false;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                Debug.LogError("AudioSaveService: Invalid file path.");
                return false;
            }

            string fullPath = relativeToPersistentDataPath 
                ? Path.Combine(Application.persistentDataPath, filePath) 
                : filePath;

            // Ensure target directory exists
            string directory = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            try
            {
                byte[] wavData = ConvertClipToWav(clip);
                File.WriteAllBytes(fullPath, wavData);
                Debug.Log($"AudioSaveService: File saved successfully to {fullPath}");
                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError($"AudioSaveService: Failed to save file. Exception: {ex.Message}");
                return false;
            }
        }

        private static byte[] ConvertClipToWav(AudioClip clip)
        {
            float[] samples = new float[clip.samples * clip.channels];
            clip.GetData(samples, 0);

            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                int sampleCount = samples.Length;
                int frequency = clip.frequency;
                ushort channels = (ushort)clip.channels;

                // RIFF Header
                writer.Write(System.Text.Encoding.UTF8.GetBytes("RIFF"));
                writer.Write(36 + sampleCount * 2);
                writer.Write(System.Text.Encoding.UTF8.GetBytes("WAVE"));

                // fmt chunk
                writer.Write(System.Text.Encoding.UTF8.GetBytes("fmt "));
                writer.Write(16); // Chunk size
                writer.Write((ushort)1); // PCM Format
                writer.Write(channels);
                writer.Write(frequency);
                writer.Write(frequency * channels * 2); // Byte rate
                writer.Write((ushort)(channels * 2)); // Block align
                writer.Write((ushort)16); // Bits per sample

                // data chunk
                writer.Write(System.Text.Encoding.UTF8.GetBytes("data"));
                writer.Write(sampleCount * 2);

                // Write 16-bit PCM audio samples
                for (int i = 0; i < sampleCount; i++)
                {
                    short intSample = (short)Mathf.Clamp(samples[i] * 32767f, short.MinValue, short.MaxValue);
                    writer.Write(intSample);
                }

                return stream.ToArray();
            }
        }
    }
}