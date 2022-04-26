using System;
using System.Collections.Generic;
using System.Text;
using LearnOpenTK.Common;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ProjekUAS
{
    class Windows : GameWindow
    {

        // Camera

        private Vector3 _lightPos = new Vector3(0.0f, 4f, 0f);
        
        //kirby
        Mesh Foot = new Mesh();
        Mesh Body = new Mesh();
        Mesh Tongue = new Mesh();
        Mesh Blackeye = new Mesh();
        Mesh Whiteeye = new Mesh();
        Mesh Crystal = new Mesh();
        Mesh Circlet = new Mesh();
        private int count = 0;
        bool turun = true;

        //rocket
        Mesh Badan = new Mesh();
        Mesh Badan2 = new Mesh();
        Mesh penyambungbadan = new Mesh();
        Mesh bolamata = new Mesh();
        Mesh mulutmata = new Mesh();
        Mesh tanganroket = new Mesh();
        Mesh api = new Mesh();
        private int count2 = 0;
        bool kirikanan = true;

        //arena
        Mesh lantaiarena = new Mesh();
        Mesh pilararena = new Mesh();
        Mesh taliarena = new Mesh();
        Mesh lantaiarena2 = new Mesh();

        //lampu
        Mesh lampu = new Mesh();
        Mesh lampu1 = new Mesh();
        Mesh lampu2 = new Mesh();

        //trophy
        Mesh trophy = new Mesh();

        //table
        Mesh table = new Mesh();
        Mesh table2 = new Mesh();

        //terrain
        Mesh floor = new Mesh();
        Mesh floor2 = new Mesh();
        Mesh floor3 = new Mesh();

        //snowman
        Mesh badansnowman = new Mesh();
        Mesh tangansnowman = new Mesh();
        Mesh hidungsnowman = new Mesh();
        Mesh matasnowman = new Mesh();

        //audience
        Mesh steve = new Mesh();
        Mesh steve2 = new Mesh();
        Mesh android = new Mesh();
        Mesh android2 = new Mesh();
        Mesh android3 = new Mesh();



        private Camera _camera;
        private Vector3 _objectPos;

        private Vector2 _lastMousePosition;
        private bool _firstmove = true;
        private float sensitivity = .1f;
        private bool notidle = false;


        public Windows(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }
        private Matrix4 generateArbRotationMatrix(Vector3 axis, Vector3 center, float degree)
        {
            var rads = MathHelper.DegreesToRadians(degree);

            var secretFormula = new float[4, 4] {
                { (float)Math.Cos(rads) + (float)Math.Pow(axis.X, 2) * (1 - (float)Math.Cos(rads)), axis.X* axis.Y * (1 - (float)Math.Cos(rads)) - axis.Z * (float)Math.Sin(rads),    axis.X * axis.Z * (1 - (float)Math.Cos(rads)) + axis.Y * (float)Math.Sin(rads),   0 },
                { axis.Y * axis.X * (1 - (float)Math.Cos(rads)) + axis.Z * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Y, 2) * (1 - (float)Math.Cos(rads)), axis.Y * axis.Z * (1 - (float)Math.Cos(rads)) - axis.X * (float)Math.Sin(rads),   0 },
                { axis.Z * axis.X * (1 - (float)Math.Cos(rads)) - axis.Y * (float)Math.Sin(rads),   axis.Z * axis.Y * (1 - (float)Math.Cos(rads)) + axis.X * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Z, 2) * (1 - (float)Math.Cos(rads)), 0 },
                { 0, 0, 0, 1}
            };
            var secretFormulaMatrix = new Matrix4(
                new Vector4(secretFormula[0, 0], secretFormula[0, 1], secretFormula[0, 2], secretFormula[0, 3]),
                new Vector4(secretFormula[1, 0], secretFormula[1, 1], secretFormula[1, 2], secretFormula[1, 3]),
                new Vector4(secretFormula[2, 0], secretFormula[2, 1], secretFormula[2, 2], secretFormula[2, 3]),
                new Vector4(secretFormula[3, 0], secretFormula[3, 1], secretFormula[3, 2], secretFormula[3, 3])
            );
            return secretFormulaMatrix;
        }
        protected override void OnLoad()
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);


            //Kirby
            Foot.LoadObjFile("../../../Objects/Foot.obj");
            Foot.setupObject((float)Size.X, (float)Size.Y, "lighting");
            Foot.setColor(new Vector3(0, 0, 1));
            Foot.scale(.1f);

            Body.LoadObjFile("../../../Objects/Body.obj");
            Body.setupObject((float)Size.X, (float)Size.Y, "lighting");
            Body.setColor(new Vector3(0.019f, 0.588f, 0.800f));
            Body.scale(.1f);

            Tongue.LoadObjFile("../../../Objects/Tongue.obj");
            Tongue.setupObject((float)Size.X, (float)Size.Y, "lighting");
            Tongue.setColor(new Vector3(0.8f, 0.074f, 0.017f));
            Tongue.scale(.1f);

            Blackeye.LoadObjFile("../../../Objects/Blackeye.obj");
            Blackeye.setupObject((float)Size.X, (float)Size.Y, "lighting");
            Blackeye.setColor(new Vector3(0.2f, 0.2f, 0.2f));
            Blackeye.scale(.1f);

            Whiteeye.LoadObjFile("../../../Objects/Whiteeye.obj");
            Whiteeye.setupObject((float)Size.X, (float)Size.Y, "lighting");
            Whiteeye.setColor(new Vector3(1, 1, 1));
            Whiteeye.scale(.1f);

            Crystal.LoadObjFile("../../../Objects/Crystal.obj");
            Crystal.setupObject((float)Size.X, (float)Size.Y, "lighting");
            Crystal.setColor(new Vector3(0.272f, 0.426f, 0.9f));
            Crystal.scale(.1f);

            Circlet.LoadObjFile("../../../Objects/Circlet.obj");
            Circlet.setupObject((float)Size.X, (float)Size.Y, "lighting");
            Circlet.setColor(new Vector3(0.8f, 0.701f, 0.0f));
            Circlet.scale(.1f);


            Body.child.Add(Tongue);
            //Body.child.Add(Foot);
            Body.child.Add(Blackeye);
            Body.child.Add(Whiteeye);
            Body.child.Add(Crystal);
            Body.child.Add(Circlet);
            Body.translate(-1.5f, -0.4f, 0.0f);
            Foot.translate(-1.5f, -0.4f, 0.0f);


            //rocket
            Badan.LoadObjFile("../../../Objects/badanroket.obj");
            Badan.setupObject((float)Size.X, (float)Size.Y, "lighting");
            Badan.setColor(new Vector3(0f, 0f, 0f));
            Badan.scale(.1f);

            Badan2.LoadObjFile("../../../Objects/badanroket2.obj");
            Badan2.setupObject((float)Size.X, (float)Size.Y, "lighting");
            Badan2.setColor(new Vector3(0f, 0f, 0f));
            Badan2.scale(.1f);

            penyambungbadan.LoadObjFile("../../../Objects/penyambungbadan.obj");
            penyambungbadan.setupObject((float)Size.X, (float)Size.Y, "lighting");
            penyambungbadan.setColor(new Vector3(1f, 1f, 1f));
            penyambungbadan.scale(.1f);

            bolamata.LoadObjFile("../../../Objects/bolamata.obj");
            bolamata.setupObject((float)Size.X, (float)Size.Y, "lighting");
            bolamata.setColor(new Vector3(1f, 1f, 1f));
            bolamata.scale(.1f);

            mulutmata.LoadObjFile("../../../Objects/mulutmata.obj");
            mulutmata.setupObject((float)Size.X, (float)Size.Y, "lighting");
            mulutmata.setColor(new Vector3(0.7607f, 0.094f, 0.027f));
            mulutmata.scale(.1f);

            tanganroket.LoadObjFile("../../../Objects/tanganroket.obj");
            tanganroket.setupObject((float)Size.X, (float)Size.Y, "lighting");
            tanganroket.setColor(new Vector3(1f, 1f, 1f));
            tanganroket.scale(.1f);

            api.LoadObjFile("../../../Objects/api.obj");
            api.setupObject((float)Size.X, (float)Size.Y, "lighting");
            api.setColor(new Vector3(0.8901f, 0.5647f, 0.1725f));
            api.scale(.1f);



            Badan.child.Add(penyambungbadan);
            Badan.child.Add(Badan2);
            Badan.child.Add(bolamata);
            Badan.child.Add(mulutmata);
            Badan.child.Add(api);
            Badan.child.Add(tanganroket);
            Badan.scale(35f);
            Badan.translate(1f, -0.95f, 0.2f);


            //arena
            lantaiarena.LoadObjFile("../../../Objects/lantaiarena.obj");
            lantaiarena.setupObject((float)Size.X, (float)Size.Y, "lighting");
            lantaiarena.setColor(new Vector3(0.501f, 0.501f, 0.501f));
            lantaiarena.scale(.1f);
            //lantaiarena.translate(0.8f, 0.21f, 0.2f);
            //lantaiarena.scale(2f);

            pilararena.LoadObjFile("../../../Objects/pilararena.obj");
            pilararena.setupObject((float)Size.X, (float)Size.Y, "lighting");
            pilararena.setColor(new Vector3(1f, 0.682f, 0.258f));
            pilararena.scale(.1f);
            pilararena.translate(0.0f, -0.15f, 0.0f);

            taliarena.LoadObjFile("../../../Objects/taliarena.obj");
            taliarena.setupObject((float)Size.X, (float)Size.Y, "lighting");
            taliarena.setColor(new Vector3(0.98f, 0.501f, 0.447f));
            taliarena.scale(.1f);
            taliarena.translate(0.0f, -0.15f, 0.0f);

            lantaiarena2.LoadObjFile("../../../Objects/lantaiarena2.obj");
            lantaiarena2.setupObject((float)Size.X, (float)Size.Y, "lighting");
            lantaiarena2.setColor(new Vector3(0.7333f, 0.6313f, 0.3098f));
            lantaiarena2.translate(0.0f, -2f, 0.0f);
            lantaiarena2.scale(.1f);

            lantaiarena.child.Add(pilararena);
            lantaiarena.child.Add(taliarena);
            lantaiarena.child.Add(lantaiarena2);
            lantaiarena.scale(2f);

            //lampu
            lampu.LoadObjFile("../../../Objects/lampu.obj");
            lampu.setupObject((float)Size.X, (float)Size.Y, "lighting");
            lampu.setColor(new Vector3(0.7921f, 0.6431f, 0.447f));
            lampu.scale(.1f);

            lampu1.LoadObjFile("../../../Objects/lampu1.obj");
            lampu1.setupObject((float)Size.X, (float)Size.Y, "lighting");
            lampu1.setColor(new Vector3(0.7921f, 0.6431f, 0.447f));
            lampu1.scale(.1f);

            lampu2.LoadObjFile("../../../Objects/lampu2.obj");
            lampu2.setupObject((float)Size.X, (float)Size.Y, "lighting");
            lampu2.setColor(new Vector3(1f, 1f, 1f));
            lampu2.scale(.1f);

            lampu.child.Add(lampu1);
            lampu.child.Add(lampu2);
            lampu.translate(0.0f, 0.0f, -4f);
            //lampu.rotate(0.0f, 2f, 0.0f);

            //trophy
            trophy.LoadObjFile("../../../Objects/trophy.obj");
            trophy.setupObject((float)Size.X, (float)Size.Y, "lighting");
            trophy.setColor(new Vector3(0.7333f, 0.6313f, 0.3098f));
            trophy.scale(0.2f);
            trophy.translate(-4.5f, -0.9f, 0.0f);

            //table
            table.LoadObjFile("../../../Objects/table.obj");
            table.setupObject((float)Size.X, (float)Size.Y, "lighting");
            table.setColor(new Vector3(0.4f, 0.2f, 0.0f));
            table.scale(0.025f);
            table.translate(-4.5f, -1.5f, 0.0f);

            table2.LoadObjFile("../../../Objects/meja.obj");
            table2.setupObject((float)Size.X, (float)Size.Y, "lighting");
            table2.setColor(new Vector3(0.4f, 0.2f, 0.0f));
            table2.scale(0.5f);
            table2.translate(-0.2f, -0.75f, 4.25f);
            //table2.translate(-4.5f, -1.5f, 0.0f);

            //floor
            floor.LoadObjFile("../../../Objects/floor.obj");
            floor.setupObject((float)Size.X, (float)Size.Y, "lighting");
            floor.setColor(new Vector3(0.1568f, 0.3647f, 0.2039f));
            floor.scale(.1f);

            floor2.LoadObjFile("../../../Objects/floor2.obj");
            floor2.setupObject((float)Size.X, (float)Size.Y, "lighting");
            floor2.setColor(new Vector3(0.1568f, 0.3647f, 0.2039f));
            floor2.scale(.1f);
            

            floor3.LoadObjFile("../../../Objects/floor3.obj");
            floor3.setupObject((float)Size.X, (float)Size.Y, "lighting");
            floor3.setColor(new Vector3(0.1568f, 0.3647f, 0.2039f));
            floor3.scale(.1f);

            floor.child.Add(floor2);
            floor.child.Add(floor3);
            floor.translate(0.0f, -1f, 0.0f);
            floor.scale(2f);

            //snowman
            badansnowman.LoadObjFile("../../../Objects/badansnowman.obj");
            badansnowman.setupObject((float)Size.X, (float)Size.Y, "lighting");
            badansnowman.setColor(new Vector3(1, 1, 1));
            badansnowman.scale(.1f);

            tangansnowman.LoadObjFile("../../../Objects/tangansnowman.obj");
            tangansnowman.setupObject((float)Size.X, (float)Size.Y, "lighting");
            tangansnowman.setColor(new Vector3(0.4f, 0.2f, 0.0f));
            tangansnowman.scale(.1f);

            matasnowman.LoadObjFile("../../../Objects/matasnowman.obj");
            matasnowman.setupObject((float)Size.X, (float)Size.Y, "lighting");
            matasnowman.setColor(new Vector3(0, 0, 0));
            matasnowman.scale(.1f);

            hidungsnowman.LoadObjFile("../../../Objects/hidungsnowman.obj");
            hidungsnowman.setupObject((float)Size.X, (float)Size.Y, "lighting");
            hidungsnowman.setColor(new Vector3(1, 0.747f, 0));
            hidungsnowman.scale(.1f);

            badansnowman.child.Add(tangansnowman);
            badansnowman.child.Add(matasnowman);
            badansnowman.child.Add(hidungsnowman);
            badansnowman.scale(35f);
            badansnowman.translate(-0.2f, 1.2f, 4.25f);

            //audience

            //steve
            steve.LoadObjFile("../../../Objects/steve.obj");
            steve.setupObject((float)Size.X, (float)Size.Y, "lighting");
            steve.setColor(new Vector3(1, 0.747f, 0));
            steve.scale(1.25f);
            steve.translate(2.75f, -1f, 6f);

            steve2.LoadObjFile("../../../Objects/steve.obj");
            steve2.setupObject((float)Size.X, (float)Size.Y, "lighting");
            steve2.setColor(new Vector3(0.545f, 0, 0));
            steve2.scale(1.25f);
            steve2.translate(-2.75f, -1f, 6f);

            //android
            android.LoadObjFile("../../../Objects/android_jobs.obj");
            android.setupObject((float)Size.X, (float)Size.Y, "lighting");
            android.setColor(new Vector3(1, 0.747f, 0));
            android.scale(4.25f);
            android.translate(5f, -1.25f, 0.0f);

            android2.LoadObjFile("../../../Objects/android_jobs.obj");
            android2.setupObject((float)Size.X, (float)Size.Y, "lighting");
            android2.setColor(new Vector3(0.98f, 0.501f, 0.447f));
            android2.scale(4.25f);
            android2.translate(5f, -1.25f, -3f);

            android3.LoadObjFile("../../../Objects/android_jobs.obj");
            android3.setupObject((float)Size.X, (float)Size.Y, "lighting");
            android3.setColor(new Vector3(0, 0, 1));
            android3.scale(4.25f);
            android3.translate(5f, -1.25f, 3f);

            // Camera
            var _cameraPosInit = new Vector3(0, 2, 4);
            _camera = new Camera(_cameraPosInit, Size.X / (float)Size.Y);

            //_camera.Yaw -= 90f;

            CursorGrabbed = true;
            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //_lampShader.Use();
            Body.render(_camera, new Vector3(1, 1, 1), _lightPos);
            Foot.render(_camera, new Vector3(1, 1, 1), _lightPos);
            Badan.render(_camera, new Vector3(1, 1, 1), _lightPos);
            lantaiarena.render(_camera, new Vector3(1, 1, 1), _lightPos);
            lampu.render(_camera, new Vector3(1, 1, 1), _lightPos);
            trophy.render(_camera, new Vector3(1, 1, 1), _lightPos);
            table.render(_camera, new Vector3(1, 1, 1), _lightPos);
            table2.render(_camera, new Vector3(1, 1, 1), _lightPos);
            floor.render(_camera, new Vector3(1, 1, 1), _lightPos);
            badansnowman.render(_camera, new Vector3(1, 1, 1), _lightPos);
            steve.render(_camera, new Vector3(1, 1, 1), _lightPos);
            steve2.render(_camera, new Vector3(1, 1, 1), _lightPos);
            android.render(_camera, new Vector3(1, 1, 1), _lightPos);
            android2.render(_camera, new Vector3(1, 1, 1), _lightPos);
            android3.render(_camera, new Vector3(1, 1, 1), _lightPos);

            //lightend--------------

            SwapBuffers();

            base.OnRenderFrame(args);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            const float cameraSpeed = 1.5f;

            //animasi
            if (turun)
            {
                Body.translate(0.0f, 0.001f, 0.0f);
                tangansnowman.translate(0.0f, 0.001f, 0.0f);
                count++;
                if (count > 50)
                {
                    turun = false;
                }
            }
            else
            {
                Body.translate(0.0f, -0.001f, 0.0f);
                tangansnowman.translate(0.0f, -0.001f, 0.0f);
                count--;
                if (count < 0)
                {
                    turun = true;
                }
            }
            if (kirikanan)
            {
                Badan.translate(0.001f, 0.0f, 0.0f);
                count2++;
                if (count > 50)
                {
                    kirikanan = false;
                }
            }
            else
            {
                Badan.translate(-0.001f, -0.0f, 0.0f);
                count2--;
                if (count < 0)
                {
                    kirikanan = true;
                }
            }

            // Escape keyboard
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            // Zoom in
            if (KeyboardState.IsKeyDown(Keys.I))
            {
                _camera.Fov -= 0.05f;
            }
            // Zoom out
            if (KeyboardState.IsKeyDown(Keys.O))
            {
                _camera.Fov += 0.05f;
            }

            //rotasi kamera pakai keyboard
            //rotasi x di pivot(pitch)
            //lihat ke atas(T)
            //if (KeyboardState.IsKeyDown(Keys.T))
            //{
            //    _camera.Pitch += 0.05f;
            //}
            ////lihat ke bawah(G)
            //if (KeyboardState.IsKeyDown(Keys.G))
            //{
            //    _camera.Pitch -= 0.05f;
            //}
            ////lihat ke kiri(F)
            //if (KeyboardState.IsKeyDown(Keys.F))
            //{
            //    _camera.Yaw -= 0.05f;
            //}
            ////lihat ke kanan(H)
            //if (KeyboardState.IsKeyDown(Keys.H))
            //{
            //    _camera.Yaw += 0.05f;
            //}

            //pindahin posisi kamera
            //maju (W)
            if (KeyboardState.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }
            //mundur (S)
            if (KeyboardState.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }
            //kiri (A)
            if (KeyboardState.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }
            //kanan (D)
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }

            //naik turun
            //naik (spasi)
            if (KeyboardState.IsKeyDown(Keys.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }
            //turun (ctrl)
            if (KeyboardState.IsKeyDown(Keys.LeftControl))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }

            const float _rotationSpeed = .02f;          
            // , (kanan -> rotasi sumbu y)
            if (KeyboardState.IsKeyPressed(Keys.Comma))
            {
                _camera.Position = new Vector3(0);
                _camera.Position += new Vector3(0, .5f, 1f);
                _camera.Pitch = 0;
                _camera.Yaw = 0;
                notidle = true;
            }
            if (KeyboardState.IsKeyReleased(Keys.Comma))
            {
                _camera.Position += new Vector3(0, .5f, 1f);
                _camera.Pitch = 0;
                _camera.Yaw = 0;
                notidle = false;
            }
            if (KeyboardState.IsKeyDown(Keys.Comma))
            {
                _objectPos *= 2;
                var axis = new Vector3(0, 15, 0);
                _camera.Position -= _objectPos;
                _camera.Yaw -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
                _objectPos /= 2;
            }
            //rotasi pakai mouse
            if (!notidle)
            {
                if (!IsFocused)
                {
                    return;
                }
                if (_firstmove)
                {
                    _lastMousePosition = new Vector2(MouseState.X, MouseState.Y);
                    _firstmove = false;
                }
                else
                {
                    //calc selisih mouse pos
                    var deltaX = MouseState.X - _lastMousePosition.X;
                    var deltaY = MouseState.Y - _lastMousePosition.Y;
                    _lastMousePosition = new Vector2(MouseState.X, MouseState.Y);

                    _camera.Yaw += deltaX * sensitivity;
                    _camera.Pitch -= deltaY * sensitivity;
                }
            }
            base.OnUpdateFrame(args);
        }
    }
}
