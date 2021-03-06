﻿using System;
using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Validators;

namespace projeto_integrado_2_sem.Casters
{
    class UserCaster : GenericTypeCaster<User>
    {
        private User user;

        public UserCaster(User user)
        {
            this.user = user;
        }

        public UserCaster() : this(new User()) { }

        public override User GetModel()
        {
            return this.user;
        }

        public override void SetModel(User model)
        {
            this.user = model;
            Reset();
        }

        public void setName(string name)
        {
            this.user.Name = name.Trim();
        }

        public void setPassword(string password)
        {
            this.user.Password = password;
            this.user.PasswordChangeDate = DateTime.Now;
        }

        public void changePassword(string currentPassword, string newPassword, string confirm)
        {
            if (this.user.CurrentPassword == null)
                this.user.CurrentPassword = this.user.Password;

            if (this.user.CurrentPassword != currentPassword)
                this.result.AddError("currentPassword", MultipleAttributeValidationResult.Error.NOT_EQUAL);

            setPassword(newPassword);
            setPasswordConfirm(confirm);
        }

        public void setPasswordConfirm(string pwdConfirm)
        {
            if (this.user.Password != pwdConfirm)
                this.result.AddError("passwordConfirm", MultipleAttributeValidationResult.Error.INVALID_CONFIRMATION);
        }

        public void setEmail(string email)
        {
            this.user.Email = email.Trim();
        }

        public void setBirthDate(string date)
        {
            var parsed = new DateTime();

            if (DateTime.TryParse(date, out parsed))
            {
                this.user.BirthDate = parsed;
            }
            else
            {
                this.result.AddError("birthDate", MultipleAttributeValidationResult.Error.INVALID_DATE);
            }
        }

        public void setProfile(string profileId)
        {
            user.Profile = null;

            if (profileId == Profile.AdminProfile().id)
                user.Profile = Profile.AdminProfile();
            if (profileId == Profile.Assistant().id)
                user.Profile = Profile.Assistant();
            if (profileId == Profile.Operator().id)
                user.Profile = Profile.Operator();

            if (user.Profile == null)
            {
                this.result.AddError("profile", MultipleAttributeValidationResult.Error.INVALID_ASSOCIATION_ID);
            }
        }

        public void setStatus(string status)
        {
            int statusInt;

            if (int.TryParse(status, out statusInt))
            {
                if (statusInt == (int)User.Status.INACTIVE)
                    user.CurrentStatus = User.Status.INACTIVE;
                else
                    if (statusInt == (int)User.Status.ACTIVE)
                        user.CurrentStatus = User.Status.ACTIVE;
                    else
                        this.result.AddError("status", MultipleAttributeValidationResult.Error.INVALID_ASSOCIATION_ID);
            }
            else
                this.result.AddError("status", MultipleAttributeValidationResult.Error.INVALID_NUMBER);
        }
    }
}
