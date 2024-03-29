﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utiilites.Interceptors;
using Core.Utiilites.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
       
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<ProfileImageManager>().As<IProfileImageService>();
            builder.RegisterType<EfProfileImageDal>().As<IProfileImageDal>();


            builder.RegisterType<MeetingManager>().As<IMeetingService>();
            builder.RegisterType<EfMeetingDal>().As<IMeetingDal>();

            builder.RegisterType<MeetingDocumentManager>().As<IMeetingDocumentService>();
            builder.RegisterType<EfMeetingDocumentDal>().As<IMeetingDocumentDal>();

            builder.RegisterType<MailManager>().As<IMailService>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
