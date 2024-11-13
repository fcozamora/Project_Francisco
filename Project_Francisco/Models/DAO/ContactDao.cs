using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Project_Francisco.Models.DTO;

namespace Project_Francisco.Models.DAO
{
    public class ContactDao
    {
        private static readonly HttpClient client = new HttpClient();

        // Método para obtener todos los contactos
        public async Task<List<ContactDto>> GetContactsAsync(string apiUrl, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseData = await response.Content.ReadAsStringAsync();
                List<ContactDto> contacts = JsonConvert.DeserializeObject<List<ContactDto>>(responseData);
                return contacts;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return new List<ContactDto>();
            }
        }

        // Método para obtener un contacto por su email
        public async Task<ContactDto> GetContactByEmailAsync(string apiUrl, string token, string email)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("b951c19c7e115f5a0c2f502635541937", token);
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/email/{email}");
                response.EnsureSuccessStatusCode();
                string responseData = await response.Content.ReadAsStringAsync();
                ContactDto contact = JsonConvert.DeserializeObject<ContactDto>(responseData);
                return contact;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null;
            }
        }

        // Método para crear un nuevo contacto
        public async Task<bool> CreateContactAsync(string apiUrl, string token, ContactDto newContact)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("b951c19c7e115f5a0c2f502635541937", token);
            try
            {
                string json = JsonConvert.SerializeObject(newContact);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return true;
            }
        }
    }
}