//using Autofac;
//using HotelProject.BusinessLayer.Abstract;
//using HotelProject.BusinessLayer.Concrete;
//using HotelProject.DataAccessLayer.Abstract;
//using HotelProject.DataAccessLayer.Concrete;
//using HotelProject.DataAccessLayer.EntityFramework;
//using HotelProject.DataAccessLayer.Repositories;
//using HotelProject.EntityLayer.Concrete;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HotelProject.BusinessLayer.DependencyResolvers.Autofac
//{
//    public class AutofacBusinessModule : Module
//    {
//        protected override void Load(ContainerBuilder builder)
//        {
//            // Context sınıfını kaydetmek için:
//            builder.RegisterType<Context>().InstancePerLifetimeScope();


//            //Birisi senden StaffManager isterse ona StaffService yi ver
//            builder.RegisterType<StaffManager>().As<IStaffService>().SingleInstance();
//            builder.RegisterType<EfStaffDal>().As<IStaffDal>().SingleInstance();

//            builder.RegisterType<ServiceManager>().As<IServiceService>().SingleInstance();
//            builder.RegisterType<EfServiceDal>().As<IServicesDal>().SingleInstance();


//            builder.RegisterType<SubscribeManager>().As<ISubscribeService>().SingleInstance();
//            builder.RegisterType<EfSubscribeDal>().As<ISubscribeDal>().SingleInstance();


//            builder.RegisterType<TestimonialManager>().As<ITestimonialService>().SingleInstance();
//            builder.RegisterType<EfTestimonialDal>().As<ITestimonialDal>().SingleInstance();


//            builder.RegisterType<RoomManager>().As<IRoomService>().SingleInstance();
//            builder.RegisterType<EfRoomDal>().As<IRoomDal>().SingleInstance();


//            //Update İşlemi için 
//            builder.RegisterType<GenericRepository<Staff>>()
//           .As<GenericRepository<Staff>>()
//           .InstancePerLifetimeScope();
//            builder.RegisterType<StaffManager>().As<IStaffService>().InstancePerLifetimeScope();


//            //Update İşlemi için 
//            builder.RegisterType<GenericRepository<Service>>()
//           .As<GenericRepository<Service>>()
//           .InstancePerLifetimeScope();
//            builder.RegisterType<ServiceManager>().As<IStaffService>().InstancePerLifetimeScope();




//            //Update İşlemi için 
//            builder.RegisterType<GenericRepository<Subscribe>>()
//           .As<GenericRepository<Subscribe>>()
//           .InstancePerLifetimeScope();
//            builder.RegisterType<SubscribeManager>().As<ISubscribeService>().InstancePerLifetimeScope();





//            //Update İşlemi için 
//            builder.RegisterType<GenericRepository<Testimonial>>()
//           .As<GenericRepository<Testimonial>>()
//           .InstancePerLifetimeScope();
//            builder.RegisterType<TestimonialManager>().As<ITestimonialService>().InstancePerLifetimeScope();




//            //Update İşlemi için 
//            builder.RegisterType<GenericRepository<Room>>()
//           .As<GenericRepository<Room>>()
//           .InstancePerLifetimeScope();
//            builder.RegisterType<RoomManager>().As<IRoomService>().InstancePerLifetimeScope();





//        }


//    }
//}
