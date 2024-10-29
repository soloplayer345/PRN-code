﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace RepositoryLayer
{
    public class MemberRepository
    {
        public List<Member> members = new List<Member>
        {
            AminAccount(),
            new Member{Id=2,Name="B",Email="B@mail.com",Password="B",City="B",Country="Not Asian" },
            new Member{Id=3,Name="Charlie",Email="Charlie@hotmail.com",Password="password",City="London",Country="UK"}
        };

        public Member Create(Member member)
        {
            members.Add(member);
            return member;
        }

        public List<Member> GetAllMembers() { return members; }

        public Member GetMember(int id) { return members[id]; }

        public void Update(int id, Member member)
        {
            members[id] = member;
        }

        public void Delete(int id)
        {
            members.RemoveAt(id);
        }

        public Member Login(string email, string password)
        {
            foreach (Member member in members)
            {
                if (member.Email == email && member.Password == password)
                {
                    return member;
                }
            }
            return null;
        }   

        private static Member AminAccount()
        {
            // Đường dẫn tới tệp JSON
            string filePath = "jsonfile.json";

            // Đọc nội dung của tệp JSON
            string jsonData = File.ReadAllText(filePath);

            // Chuyển đổi JSON thành đối tượng C#
            Member admin = JsonConvert.DeserializeObject<Member>(jsonData);
            return admin;
        }
    }
}